using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Pokedex.Models
{
  public class PokedexContext : DbContext
  {
    public PokedexContext(DbContextOptions<PokedexContext> options)
      : base(options)
    {   
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Pokemon>()
        .HasData(
          // new Pokemon { PokemonId = , NationalPokedexNumber = , PokemonName = , PrimaryType = , SecondaryType = , EvolvesFrom = , EvolvesTo = , Details = ,}
          new Pokemon { PokemonId =1 , NationalPokedexNumber =1 , PokemonName = "Bulbasaur", PrimaryType = "Grass", SecondaryType = "Poison", EvolvesFrom = "n/a", EvolvesTo = "Ivysaur", Details = "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely tough and very difficult to capture in the wild." },
          new Pokemon { PokemonId =2 , NationalPokedexNumber =2 , PokemonName = "Ivysaur", PrimaryType = "Grass", SecondaryType = "Poison", EvolvesFrom = "Bulbasaur", EvolvesTo = "Venusaur", Details = "As Ivysaur takes in nutrients, a large flower blooms from the bulb on its back." },
          new Pokemon { PokemonId =3 , NationalPokedexNumber =3 , PokemonName = "Venusaur", PrimaryType = "Grass", SecondaryType = "Poison", EvolvesFrom = "Ivysaur", EvolvesTo = "n/a", Details = "When Venusaur spreads out its large flower petals and absorbs the rays of the sun, it becomes energized." },
          new Pokemon { PokemonId =4 , NationalPokedexNumber =4 , PokemonName = "Charmander", PrimaryType = "Fire", SecondaryType = "n/a", EvolvesFrom = "n/a", EvolvesTo = "Charmeleon", Details = " A flame burns on the tip of its tail from birth. It is said that a Charmander dies if its flame never goes out." },
          new Pokemon { PokemonId =5 , NationalPokedexNumber =5 , PokemonName = "Charmeleon", PrimaryType = "Fire", SecondaryType = "n/a", EvolvesFrom = "Charmander", EvolvesTo = "Charizard", Details = "Charmeleon, the Flame Pokémon. It has razor-sharp claws and its tail is exceptionally strong." },
          new Pokemon { PokemonId =6 , NationalPokedexNumber =6 , PokemonName = "Charizard", PrimaryType = "Fire" , SecondaryType = "Flying", EvolvesFrom = "Charmeleon" , EvolvesTo = "n/a", Details = "Charizard, the Flame Pokémon. Charizard's powerful flame can melt absolutely anything." },
          new Pokemon { PokemonId =7 , NationalPokedexNumber =7 , PokemonName = "Squirtle", PrimaryType = "Water" , SecondaryType = "n/a" , EvolvesFrom = "n/a", EvolvesTo = "Wartortle" , Details = "Squirtle. This Tiny Turtle Pokémon draws its long neck into its shell to launch incredible Water attacks with amazing range and accuracy. The blasts can be quite powerful." },
          new Pokemon { PokemonId =8 , NationalPokedexNumber =8 , PokemonName = "Wartortle", PrimaryType = "Water" , SecondaryType = "n/a", EvolvesFrom = "Squirtle" , EvolvesTo = "Blastoise" , Details = "Wartortle, the Turtle Pokémon. The evolved form of Squirtle. Its long furry tail is a symbol of its age and wisdom." },
          new Pokemon { PokemonId =9 , NationalPokedexNumber =9 , PokemonName = "Blastoise" , PrimaryType = "Water" , SecondaryType = "n/a" , EvolvesFrom = "Wartortle" , EvolvesTo = "n/a" , Details = "Blastoise, the Shellfish Pokémon. The evolved form of Wartortle. Blastoise's strength lies in its power, rather than its speed. Its shell is like armor and attacks from the hydro cannon on its back are virtually unstoppable." }
        );
    }

    public DbSet<Pokemon> PokedexDatabase { get; set; }
  }
} 