
namespace GamesStudio.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _DbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public IEnumerable<SelectListItem> GetSelectedLists()
        {
            return _DbContext.Categories.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Name })
                    .OrderBy(e => e.Text)
                    .AsNoTracking()
                    .ToList();
        }
    }
}
