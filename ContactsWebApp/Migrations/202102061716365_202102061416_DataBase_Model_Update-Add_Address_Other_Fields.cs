namespace ContactsWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202102061416_DataBase_Model_UpdateAdd_Address_Other_Fields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "Country", c => c.String());
            AddColumn("dbo.Contacts", "ZipCode", c => c.String());
            AddColumn("dbo.Contacts", "State", c => c.String());
            AddColumn("dbo.Contacts", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "City");
            DropColumn("dbo.Contacts", "State");
            DropColumn("dbo.Contacts", "ZipCode");
            DropColumn("dbo.Contacts", "Country");
        }
    }
}
