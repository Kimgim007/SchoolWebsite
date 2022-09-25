namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        LectureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LectureDTOes", t => t.LectureId, cascadeDelete: true)
                .ForeignKey("dbo.StudentDTOes", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.LectureId);
            
            CreateTable(
                "dbo.LectureDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        itemName = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubjectDTOes", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherDTOes", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.SubjectDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                        ZP = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScientificWorkDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubjectId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentDTOes", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectDTOes", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.TeacherDTOes", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ScientificWorkDTOes", "TeacherId", "dbo.TeacherDTOes");
            DropForeignKey("dbo.ScientificWorkDTOes", "SubjectId", "dbo.SubjectDTOes");
            DropForeignKey("dbo.ScientificWorkDTOes", "StudentId", "dbo.StudentDTOes");
            DropForeignKey("dbo.GradeDTOes", "StudentId", "dbo.StudentDTOes");
            DropForeignKey("dbo.LectureDTOes", "TeacherId", "dbo.TeacherDTOes");
            DropForeignKey("dbo.LectureDTOes", "SubjectId", "dbo.SubjectDTOes");
            DropForeignKey("dbo.GradeDTOes", "LectureId", "dbo.LectureDTOes");
            DropIndex("dbo.ScientificWorkDTOes", new[] { "StudentId" });
            DropIndex("dbo.ScientificWorkDTOes", new[] { "TeacherId" });
            DropIndex("dbo.ScientificWorkDTOes", new[] { "SubjectId" });
            DropIndex("dbo.LectureDTOes", new[] { "TeacherId" });
            DropIndex("dbo.LectureDTOes", new[] { "SubjectId" });
            DropIndex("dbo.GradeDTOes", new[] { "LectureId" });
            DropIndex("dbo.GradeDTOes", new[] { "StudentId" });
            DropTable("dbo.StudentDTOes");
            DropTable("dbo.ScientificWorkDTOes");
            DropTable("dbo.TeacherDTOes");
            DropTable("dbo.SubjectDTOes");
            DropTable("dbo.LectureDTOes");
            DropTable("dbo.GradeDTOes");
        }
    }
}
