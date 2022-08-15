using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pokedex.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokedexDatabase",
                columns: table => new
                {
                    PokemonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NationalPokedexNumber = table.Column<int>(type: "int", nullable: false),
                    PokemonName = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    PrimaryType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    SecondaryType = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EvolvesFrom = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EvolvesTo = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Details = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokedexDatabase", x => x.PokemonId);
                });

            migrationBuilder.InsertData(
                table: "PokedexDatabase",
                columns: new[] { "PokemonId", "Details", "EvolvesFrom", "EvolvesTo", "NationalPokedexNumber", "PokemonName", "PrimaryType", "SecondaryType" },
                values: new object[,]
                {
                    { 1, "It bears the seed of a plant on its back from birth. The seed slowly develops. Researchers are unsure whether to classify Bulbasaur as a plant or animal. Bulbasaur are extremely tough and very difficult to capture in the wild.", "n/a", "Ivysaur", 1, "Bulbasaur", "Grass", "Poison" },
                    { 2, "As Ivysaur takes in nutrients, a large flower blooms from the bulb on its back.", "Bulbasaur", "Venusaur", 2, "Ivysaur", "Grass", "Poison" },
                    { 3, "When Venusaur spreads out its large flower petals and absorbs the rays of the sun, it becomes energized.", "Ivysaur", "n/a", 3, "Venusaur", "Grass", "Poison" },
                    { 4, " A flame burns on the tip of its tail from birth. It is said that a Charmander dies if its flame never goes out.", "n/a", "Charmeleon", 4, "Charmander", "Fire", "n/a" },
                    { 5, "Charmeleon, the Flame Pokémon. It has razor-sharp claws and its tail is exceptionally strong.", "Charmander", "Charizard", 5, "Charmeleon", "Fire", "n/a" },
                    { 6, "Charizard, the Flame Pokémon. Charizard's powerful flame can melt absolutely anything.", "Charmeleon", "n/a", 6, "Charizard", "Fire", "Flying" },
                    { 7, "Squirtle. This Tiny Turtle Pokémon draws its long neck into its shell to launch incredible Water attacks with amazing range and accuracy. The blasts can be quite powerful.", "n/a", "Wartortle", 7, "Squirtle", "Water", "n/a" },
                    { 8, "Wartortle, the Turtle Pokémon. The evolved form of Squirtle. Its long furry tail is a symbol of its age and wisdom.", "Squirtle", "Blastoise", 8, "Wartortle", "Water", "n/a" },
                    { 9, "Blastoise, the Shellfish Pokémon. The evolved form of Wartortle. Blastoise's strength lies in its power, rather than its speed. Its shell is like armor and attacks from the hydro cannon on its back are virtually unstoppable.", "Wartortle", "n/a", 9, "Blastoise", "Water", "n/a" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokedexDatabase");
        }
    }
}
