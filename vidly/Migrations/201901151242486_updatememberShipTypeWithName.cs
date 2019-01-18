namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatememberShipTypeWithName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'PAY AS YOU GO' where Id = 1");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'MONTHLY' where Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
