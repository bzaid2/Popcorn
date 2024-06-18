using Popcorn.Models.ReponseDto;
using System.Threading.Tasks;

namespace Popcorn.Interfaces
{
    public interface IMovie
    {
        Task<Root> GetListOfMoviesByPageAsync(int page);
        Group SelectedMovie { get; set; }
    }
}
