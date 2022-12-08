using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using PokemonDatabase.API.Models;

namespace PokemonDatabase.API.Mapping
{
    public class PokemonMapping : ClassMap<Pokemon>
    {
        public PokemonMapping()
        {
            Table("Pokemon");
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Name);
            Map(p => p.Height);
            Map(p => p.Weight);
            //HasOne(p => p.Type).PropertyRef(p => p.Id).ForeignKey("PokemonTypeId").Cascade.All();
        }

    }
}
