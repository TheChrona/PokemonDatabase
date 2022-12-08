using FluentMigrator;

namespace PokemonDatabase.API.Migrations
{
    [Migration(20221207214425)]
    public class AddTrainerTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("Trainer")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Team").AsString()
                .WithColumn("Gender").AsString();

            Insert
                .IntoTable("Trainer")
                .Row(new
                {
                    Name = "Ash Ketchup",
                    Team = "Independent",
                    Gender = "Male"
                });
        }

        public override void Down()
        {
            Delete.Table("Trainer");
        }

    }
}
