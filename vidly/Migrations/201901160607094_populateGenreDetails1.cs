namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenreDetails1 : DbMigration
    {
        public override void Up()
        {
            Sql("delete from Genres");
                }
        
        public override void Down()
        {
        }
    }
}
