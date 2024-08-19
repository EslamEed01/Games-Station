
using Games_Station.ViewModels;
using GamesStudio.Data;
using GamesStudio.Models;

namespace GamesStudio.Services
{
    public class GamesServices : IGamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _ImagesPath;

        public GamesServices(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _ImagesPath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }


        public IEnumerable<Game> GetAll()
        {
            return _context.Games
                .Include(g => g.Category)
                .Include(n => n.Devices)
                .ThenInclude(a => a.Device)
                .AsNoTracking()
                .ToList();
            // var games = _context.Games
            //.AsNoTracking()
            //.ToList();
            //return games
        }

        public async Task Create(CreateGameFormVM Model)
        {
            var coverName = await SaveCover(Model.Cover);

            Game Games = new()
            {
                Name = Model.Name,
                Description = Model.Description,
                CategoryId = Model.CategoriesId,
                Cover = coverName,

                Devices = Model.SelectedDevices.Select(e => new GameDevice { DeviceId = e }).ToList()


            };
            _context.Add(Games);
            _context.SaveChanges();
        }

        public Game? GetById(int id)
        {
            return _context.Games
                .Include(g => g.Category)
                .Include(n => n.Devices)
                .ThenInclude(a => a.Device)
                .AsNoTracking()
                .SingleOrDefault(q => q.Id == id);

        }

        public async Task<Game?> Update(EditGameFormVM model)
        {
            var game = _context.Games
                .Include(g => g.Devices)
                .SingleOrDefault(g => g.Id == model.id);
            if (game is null) return null;

            var HasNewCover = model.Cover is not null;
            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoriesId;
            game.Devices = model.SelectedDevices.Select(e => new GameDevice { DeviceId = e }).ToList();

            if (HasNewCover)
            {
                game.Cover = await SaveCover(model.Cover!);
            }
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (HasNewCover)
                {
                    var cover = Path.Combine(_ImagesPath, oldCover);
                    File.Delete(cover);
                }

                return game;
            }
            else
            {
                var cover = Path.Combine(_ImagesPath, game.Cover);
                File.Delete(cover);

                return null;
            }

        }
        public bool Delete(int id)
        {
			var isDeleted = false;

			var game = _context.Games.Find(id);

			if (game is null)
				return isDeleted;

			_context.Remove(game);
			var effectedRows = _context.SaveChanges();

			if (effectedRows > 0)
			{
				isDeleted = true;

				var cover = Path.Combine(_ImagesPath, game.Cover);
				File.Delete(cover);
			}

			return isDeleted;



		}
    

		private async Task<string> SaveCover(IFormFile cover)// achieve DRY principle
		{
			var CoverName = $"{Guid.NewGuid()} {Path.GetExtension(cover.FileName)}";
			var path = Path.Combine(_ImagesPath, CoverName);
			using var stream = File.Create(path);
			await cover.CopyToAsync(stream);

			return CoverName;
		}

		
	}
}
