using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;

namespace Pokedex.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PokemonController : ControllerBase
  {
    private readonly PokedexContext _db;

    public PokemonController(PokedexContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pokemon>>> Get(string pokemonname, string primarytype, string secondarytype, string evolvesfrom, string evolvesto, string details)
    {
      var query = _db.PokedexDatabase.AsQueryable();

      if (pokemonname != null)
      {
        query = query.Where(entry => entry.PokemonName == pokemonname);
      }

       if (primarytype != null)
      {
        query = query.Where(entry => entry.PrimaryType == primarytype);
      }

       if (secondarytype != null)
      {
        query = query.Where(entry => entry.SecondaryType == secondarytype);
      }
    
      if (evolvesfrom != null)
      {
        query = query.Where(entry => entry.EvolvesFrom == evolvesfrom);
      }

      if (evolvesto != null)
      {
        query = query.Where(entry => entry.EvolvesTo == evolvesto);
      }
      
      if (details != null)
      {
        query = query.Where(entry => entry.Details == details);
      }

      return await query.ToListAsync();
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult<Pokemon>> GetPokemon(int id)
    // {
    //   var pokemon = await _db.PokedexDatabase.FindAsync(id);
    //   if (pokemon == null)
    //   {
    //       return NotFound();
    //   }
    //   return pokemon;
    // }

    [HttpGet("{page}")]
    public async Task<ActionResult<List<Pokemon>>> GetPokedexDatabase(int page)
    {
      if (_db.PokedexDatabase == null)
        return NotFound();
      
      var pageResults = 3f;
      var pageCount = Math.Ceiling(_db.PokedexDatabase.Count() / pageResults);

      var pokedexDatabase = await _db.PokedexDatabase
      .Skip((page - 1) * (int)pageResults)
      .Take((int)pageResults)
      .ToListAsync();

      var response = new PokemonResponse
      {
        PokedexDatabase = pokedexDatabase,
        CurrentPage = page,
        Pages = (int)pageCount
      };
      return Ok(response);
    }

     // PUT: api/Pokemon/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Pokemon pokemon)
    {
      if (id != pokemon.PokemonId)
      {
        return BadRequest();
      }

      _db.Entry(pokemon).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PokemonExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
     private bool PokemonExists(int id)
    {
      return _db.PokedexDatabase.Any(e => e.PokemonId == id);
    }

    //   // POST: api/Pokemon
    // [HttpPost]
    // public async Task<ActionResult<Pokemon>> Post(Pokemon pokemon)
    // {
    //   _db.PokedexDatabase.Add(pokemon);
    //   await _db.SaveChangesAsync();

    //   return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.PokemonId }, pokemon);
    // }

    // DELETE: api/Pokemon/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePokemon(int id)
    {
      var pokemon = await _db.PokedexDatabase.FindAsync(id);
      if (pokemon == null)
      {
        return NotFound();
      }

      _db.PokedexDatabase.Remove(pokemon);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}