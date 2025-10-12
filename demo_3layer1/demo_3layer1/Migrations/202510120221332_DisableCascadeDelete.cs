namespace demo_3layer1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisableCascadeDelete : DbMigration
    {
        public override void Up()
        {
            // CourseRegistrations -> Subjects
            DropForeignKey("dbo.CourseRegistrations", "SubjectId", "dbo.Subjects");
            AddForeignKey("dbo.CourseRegistrations", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: false);

            // Grades -> Subjects
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            AddForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: false);
        }

        public override void Down()
        {
            // Khôi phục về có cascade như ban đầu
            DropForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects");
            AddForeignKey("dbo.Grades", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);

            DropForeignKey("dbo.CourseRegistrations", "SubjectId", "dbo.Subjects");
            AddForeignKey("dbo.CourseRegistrations", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
    }
}
