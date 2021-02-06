namespace ContactsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202102061158_DataBase_Model_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "AddressLine1", c => c.String());
            AddColumn("dbo.Contacts", "AddressLine2", c => c.String());
            DropColumn("dbo.Contacts", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "Address", c => c.String());
            DropColumn("dbo.Contacts", "AddressLine2");
            DropColumn("dbo.Contacts", "AddressLine1");
        }
    }
}
