using FluentMigrator;

namespace PokemonDatabase.API.Migrations
{
    [Migration(20221207170506)]
    public class AddPokemonTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("PokemonType")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString();

            Insert
                .IntoTable("PokemonType")
                .Row(new
                {
                    Name = "Grama"
                })
                .Row(new
                {
                    Name = "Fantasma"
                })
                .Row(new
                {
                    Name = "Fogo"
                });

            Create
                .Table("Pokemon")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString()
                .WithColumn("Height").AsDouble().NotNullable().WithDefaultValue(0)
                .WithColumn("Weight").AsDouble().NotNullable().WithDefaultValue(0);
                //.WithColumn("PokemonTypeId").AsInt64().ForeignKey("PokemonType", "Id").Unique();

            Insert
                .IntoTable("Pokemon")
                .Row(new
                {
                    Name = "Charmander",
                    Weight = 1.0,
                    Height = 0.6,
                    //PokemonTypeId = 3
                });

        }
        public override void Down()
        {
            Delete.Table("PokemonType");
            Delete.Table("Pokemon");
        }
    }
}
