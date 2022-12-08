namespace PokemonDatabase.API.Models
{
    public class Trainer : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Team { get; set; }
        public virtual string Gender { get; set; }
    }
}
