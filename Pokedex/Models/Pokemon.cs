namespace Pokedex.Models
{
  public class Pokemon
  {
    public int PokemonId { get; set; }
    public int NationalPokedexNumber { get; set; }
    public string PokemonName { get; set; }
    public string PrimaryType { get; set; }
    public string SecondaryType { get; set; }
    public string EvolvesFrom { get; set; }
    public string EvolvesTo { get; set; }
    public string Details { get; set; }
  }
}