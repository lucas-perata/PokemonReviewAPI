using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetReviewers();

        Reviewer GetReviewer(int reviewerId);

        ICollection<Review> GetReviewsByReviewer(int reviewerId);

        bool ReviewerExists(int reviewerId);
    }
}
