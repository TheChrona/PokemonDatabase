using FluentNHibernate.Mapping;
using PokemonDatabase.API.Models;

namespace PokemonDatabase.API.Mapping
{
    public class TrainerMapping : ClassMap<Trainer>
    {
        public TrainerMapping()
        {
            Table("Trainer");
            Id(pt => pt.Id).GeneratedBy.Identity();
            Map(pt => pt.Name);
            Map(pt => pt.Team);
            Map(pt => pt.Gender);
        }
    }
}
