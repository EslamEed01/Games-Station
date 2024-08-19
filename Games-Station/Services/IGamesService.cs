using Games_Station.ViewModels;
using GamesStudio.ViewModels;

namespace GamesStudio.Services
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameFormVM Games);
		Task<Game?> Update(EditGameFormVM Games);
        bool Delete(int id);

	}
}
