namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.Department", "InstructorID", "dbo.Instructor");
            DropForeignKey("dbo.Course", "DepartmentID", "dbo.Department");
            DropForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course");
            DropForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Instructor");
            DropIndex("dbo.Course", new[] { "DepartmentID" });
            DropIndex("dbo.Department", new[] { "InstructorID" });
            DropIndex("dbo.OfficeAssignment", new[] { "InstructorID" });
            DropIndex("dbo.CourseInstructor", new[] { "CourseID" });
            DropIndex("dbo.CourseInstructor", new[] { "InstructorID" });
            AddColumn("dbo.Student", "FirstMidName", c => c.String());
            AlterColumn("dbo.Course", "Title", c => c.String());
            AlterColumn("dbo.Student", "LastName", c => c.String());
            DropColumn("dbo.Course", "DepartmentID");
            DropColumn("dbo.Student", "FirstName");
            DropTable("dbo.Department");
            DropTable("dbo.Instructor");
            DropTable("dbo.OfficeAssignment");
            DropTable("dbo.CourseInstructor");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CourseInstructor",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        InstructorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.InstructorID });
            
            CreateTable(
                "dbo.OfficeAssignment",
                c => new
                    {
                        InstructorID = c.Int(nullable: false),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.InstructorID);
            
            CreateTable(
                "dbo.Instructor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(maxLength: 50),
                        FirstName = c.String(maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Budget = c.Decimal(nullable: false, storeType: "money"),
                        StartDate = c.DateTime(nullable: false),
                        InstructorID = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            AddColumn("dbo.Student", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Course", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Course", "Title", c => c.String(maxLength: 50));
            DropColumn("dbo.Student", "FirstMidName");
            CreateIndex("dbo.CourseInstructor", "InstructorID");
            CreateIndex("dbo.CourseInstructor", "CourseID");
            CreateIndex("dbo.OfficeAssignment", "InstructorID");
            CreateIndex("dbo.Department", "InstructorID");
            CreateIndex("dbo.Course", "DepartmentID");
            AddForeignKey("dbo.CourseInstructor", "InstructorID", "dbo.Instructor", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CourseInstructor", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
            AddForeignKey("dbo.Course", "DepartmentID", "dbo.Department", "DepartmentID", cascadeDelete: true);
            AddForeignKey("dbo.Department", "InstructorID", "dbo.Instructor", "ID");
            AddForeignKey("dbo.OfficeAssignment", "InstructorID", "dbo.Instructor", "ID");
        }
    }
}
