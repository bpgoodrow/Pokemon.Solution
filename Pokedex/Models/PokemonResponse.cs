using System.Collections.Generic;

namespace Pokedex.Models
{
  public class PokemonResponse
  {
    public List<Pokemon> PokedexDatabase { get; set; } = new List<Pokemon>();
    public int Pages { get; set; }
    public int CurrentPage { get; set; }
  }
}