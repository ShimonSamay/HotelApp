namespace HotelApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGuestsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        BirthDate = c.String(),
                        CheckInDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Guests");
        }
    }
}
