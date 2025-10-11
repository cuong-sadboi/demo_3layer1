namespace demo_3layer1.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class LinkStudentToUser : DbMigration
    {
        public override void Up()
        {
            // 1) Thêm cột UserId nếu chưa có
            Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.columns 
               WHERE Name = N'UserId' AND Object_ID = Object_ID(N'dbo.Students'))
    ALTER TABLE dbo.Students ADD UserId INT NULL;
");

            // 2) Nếu lỡ có cột 'User_Id' cũ thì mới drop (và drop luôn FK của nó nếu có)
            Sql(@"
IF EXISTS (SELECT 1 FROM sys.columns 
           WHERE Name = N'User_Id' AND Object_ID = Object_ID(N'dbo.Students'))
BEGIN
    -- tìm và drop mọi FK trỏ tới cột User_Id
    DECLARE @sql NVARCHAR(MAX) = N'';
    SELECT @sql = @sql + N'ALTER TABLE dbo.Students DROP CONSTRAINT ' + QUOTENAME(fk.name) + ';'
    FROM sys.foreign_keys fk
    WHERE fk.parent_object_id = OBJECT_ID(N'dbo.Students') 
      AND fk.name LIKE '%User%';

    IF (@sql <> N'') EXEC sp_executesql @sql;

    ALTER TABLE dbo.Students DROP COLUMN User_Id;
END
");

            // 3) Tạo FK chuẩn UserId -> Users(Id) nếu chưa có
            Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.foreign_keys 
               WHERE name = N'FK_Students_Users_UserId')
    ALTER TABLE dbo.Students
    ADD CONSTRAINT FK_Students_Users_UserId
    FOREIGN KEY (UserId) REFERENCES dbo.Users(Id);
");

            // 4) Tạo unique index (filter) để đảm bảo 1-1 (nếu cần)
            Sql(@"
IF NOT EXISTS (SELECT 1 FROM sys.indexes 
               WHERE name = N'UX_Students_UserId' AND object_id = OBJECT_ID(N'dbo.Students'))
    CREATE UNIQUE INDEX UX_Students_UserId ON dbo.Students(UserId) WHERE UserId IS NOT NULL;
");
        }

        public override void Down()
        {
            // Hạ ngược: bỏ index, FK, cột (nếu tồn tại)
            Sql(@"
IF EXISTS (SELECT 1 FROM sys.indexes 
           WHERE name = N'UX_Students_UserId' AND object_id = OBJECT_ID(N'dbo.Students'))
    DROP INDEX UX_Students_UserId ON dbo.Students;

IF EXISTS (SELECT 1 FROM sys.foreign_keys 
           WHERE name = N'FK_Students_Users_UserId')
    ALTER TABLE dbo.Students DROP CONSTRAINT FK_Students_Users_UserId;

IF EXISTS (SELECT 1 FROM sys.columns 
           WHERE Name = N'UserId' AND Object_ID = Object_ID(N'dbo.Students'))
    ALTER TABLE dbo.Students DROP COLUMN UserId;
");
        }
    }

}
