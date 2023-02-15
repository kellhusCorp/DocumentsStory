namespace DocumentsStory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDocumentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        LastUpdateAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documents");
        }
    }
}
