namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rePopulateGenres : DbMigration
    {
        public override void Up()
        {

            Sql("insert into Genres (id, name) values (1, 'Action')");
            Sql("insert into Genres (id, name) values (2, 'Family')");
            Sql("insert into Genres (id, name) values (3, 'Comedy')");
            Sql("insert into Genres (id, name) values (4, 'Romance')");
            Sql("insert into Genres (id, name) values (5, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
