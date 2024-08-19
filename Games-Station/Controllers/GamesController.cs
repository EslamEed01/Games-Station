using Games_Station.ViewModels;
using GamesStudio.Services;
using GamesStudio.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameStudio.Controllers
{
    public class GamesController : Controller
    {

        private readonly ICategoriesService _CategoriesService;
        private readonly IDevicesService _DevicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ICategoriesService categoriesService
            , IDevicesService devicesServices
            , IGamesService gamesService
            )
        {

            _CategoriesService = categoriesService;
            _DevicesService = devicesServices;
            _gamesService = gamesService;
        }

        public IActionResult Index()
        {
            var games = _gamesService.GetAll();
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _gamesService.GetById(id);

            if(game is null)
            {
                return NotFound();
            }
            return View(game);
        }




        [HttpGet]
        public IActionResult Create()
        {

            CreateGameFormVM createGameFormVM = new()
            {
                Categories = _CategoriesService.GetSelectedLists(),

                Devices = _DevicesService.GetDevicesList()

            };

            return View(createGameFormVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormVM Model)
        {
            if (!ModelState.IsValid)
            {
                Model.Categories = _CategoriesService.GetSelectedLists();
                Model.Devices = _DevicesService.GetDevicesList();

                return View(Model);
            }
            // save form in database 
            await _gamesService.Create(Model);
            // save cover in server


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var game = _gamesService.GetById(id);

            if (game is null)
            {
                return NotFound();
            }

            EditGameFormVM viewmodel = new()
            {
                id = id,
                Name = game.Name,
                Description = game.Description,
                CategoriesId = game.CategoryId,
                SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
                Categories = _CategoriesService.GetSelectedLists(),
                Devices = _DevicesService.GetDevicesList(),
                CurrentCover = game.Cover
            };
            return View(viewmodel);

        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFormVM Model)
		{
			if (!ModelState.IsValid)
			{
				Model.Categories = _CategoriesService.GetSelectedLists();
				Model.Devices = _DevicesService.GetDevicesList();

				return View(Model);
			}
			
	      var game=	await _gamesService.Update(Model);
            if (game is null) return BadRequest();


			return RedirectToAction(nameof(Index));
		}

      //  [HttpDelete]
        public IActionResult Delete(int id)
        {
			var isDeleted = _gamesService.Delete(id);

			return isDeleted ? Ok() : BadRequest();
		}






	}
}