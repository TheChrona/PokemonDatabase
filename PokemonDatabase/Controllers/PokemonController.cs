using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NHibernate;
using PokemonDatabase.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonDatabase.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly ISession _session;

        public PokemonController(ILogger<PokemonController> logger, ISession session)
        {
            _logger = logger;
            _session = session;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pokemon pokemon)
        {
            var createdPokemonId = await _session.SaveAsync(pokemon);
            pokemon.Id = int.Parse(createdPokemonId.ToString());
            return Ok(pokemon);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pokemonList = _session.Query<Pokemon>().ToList();
            return Ok(pokemonList);
        }

        [HttpGet("count")]
        public IActionResult GetPokemonCount()
        {
            var pokemonList = _session.Query<Pokemon>().ToList();
            return Ok(pokemonList.Count);
        }

        [HttpGet("trainer")]
        public IActionResult GetTrainers()
        {
            var trainers = _session.Query<Trainer>().ToList();
            trainers.Where(x => x.Team == "Independent");
            return Ok(trainers);
        }
    }
}
