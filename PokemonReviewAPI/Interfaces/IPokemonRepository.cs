using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeID);

        bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon);

        bool Save();
    }
}
