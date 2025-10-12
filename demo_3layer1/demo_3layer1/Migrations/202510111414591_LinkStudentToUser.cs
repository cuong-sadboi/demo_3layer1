namespace demo_3layer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class LinkStudentToUser : DbMigration
    {
        public override void Up()
        {
            // 1) Thêm cột UserId nếu chưa có (để NULL cho linh hoạt)
            Sql(@"
IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE Name = N'UserId' 
      AND Object_ID = Object_ID(N'dbo.Students')
)
BEGIN
    ALTER TABLE dbo.Students ADD UserId INT NULL;
END
");

            // 2) Tạo FK nếu chưa có
            Sql(@"
IF NOT EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = N'FK_Students_Users_UserId'
)
BEGIN
    ALTER TABLE dbo.Students
    ADD CONSTRAINT FK_Students_Users_UserId
    FOREIGN KEY (UserId) REFERENCES dbo.Users(Id);
END
");

            // 3) Unique index cho UserId nhưng **cho phép nhiều NULL** (filtered unique)
            Sql(@"
IF NOT EXISTS (
    SELECT 1 FROM sys.indexes 
    WHERE name = N'UX_Students_UserId' 
      AND object_id = OBJECT_ID(N'dbo.Students')
)
BEGIN
    CREATE UNIQUE NONCLUSTERED INDEX UX_Students_UserId
    ON dbo.Students(UserId)
    WHERE UserId IS NOT NULL;
END
");
        }

        public override void Down()
        {
            // Xóa index nếu tồn tại
            Sql(@"
IF EXISTS (
    SELECT 1 FROM sys.indexes 
    WHERE name = N'UX_Students_UserId' 
      AND object_id = OBJECT_ID(N'dbo.Students')
)
BEGIN
    DROP INDEX UX_Students_UserId ON dbo.Students;
END
");

            // Xóa FK nếu tồn tại
            Sql(@"
IF EXISTS (
    SELECT 1 
    FROM sys.foreign_keys 
    WHERE name = N'FK_Students_Users_UserId'
)
BEGIN
    ALTER TABLE dbo.Students
    DROP CONSTRAINT FK_Students_Users_UserId;
END
");

            // (Tùy chọn) Không drop cột nếu bạn đã dùng dữ liệu. 
            // Nếu muốn rollback sạch thì mở comment sau:
            /*
            Sql(@"
    IF EXISTS (
        SELECT 1 FROM sys.columns 
        WHERE Name = N'UserId' 
          AND Object_ID = Object_ID(N'dbo.Students')
    )
    BEGIN
        ALTER TABLE dbo.Students DROP COLUMN UserId;
    END
    ");
            */
        }
    }
}