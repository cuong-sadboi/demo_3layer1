namespace demo_3layer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkStudentToUser : DbMigration
    {
        public override void Up()
        {
            // Thêm cột UserId (nullable)
            AddColumn("dbo.Students", "UserId", c => c.Int());

            // Tạo chỉ mục (unique khi NOT NULL) — EF6 không có filtered index built-in,
            // nên dùng SQL thuần để đảm bảo 1 user chỉ gắn 1 student
            Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.indexes 
               WHERE name = N'UX_Students_UserId' AND object_id = OBJECT_ID(N'dbo.Students'))
    CREATE UNIQUE INDEX UX_Students_UserId ON dbo.Students(UserId) WHERE UserId IS NOT NULL;
");

            // Tạo khóa ngoại Student.UserId -> Users.Id (cho phép null)
            AddForeignKey("dbo.Students", "UserId", "dbo.Users", "Id");
            CreateIndex("dbo.Students", "UserId"); // index phụ trợ (không unique) cho join
        }

        public override void Down()
        {
            // Hạ ngược
            DropIndex("dbo.Students", new[] { "UserId" });
            Sql(@"
IF EXISTS (SELECT 1 FROM sys.indexes 
           WHERE name = N'UX_Students_UserId' AND object_id = OBJECT_ID(N'dbo.Students'))
    DROP INDEX UX_Students_UserId ON dbo.Students;
");
            DropForeignKey("dbo.Students", "UserId", "dbo.Users");
            DropColumn("dbo.Students", "UserId");
        }
    }
}
