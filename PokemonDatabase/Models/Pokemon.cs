using System.Collections;
using System.Collections.Generic;

namespace PokemonDatabase.API.Models
{
    public class Pokemon : Entity
    {
        public virtual string Name { get; set; }
        public virtual double Height { get; set; }
        public virtual double Weight { get; set; }
        //public virtual PokemonType Type { get; set; }
    }
}
