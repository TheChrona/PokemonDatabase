using FluentNHibernate.Mapping;
using PokemonDatabase.API.Models;

namespace PokemonDatabase.API.Mapping
{
    public class PokemonTypeMapping : ClassMap<PokemonType>
    {
        public PokemonTypeMapping()
        {
            Table("PokemonType");
            Id(pt => pt.Id).GeneratedBy.Identity();
            Map(pt => pt.Name);
        }
    }
}
