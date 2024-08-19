
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamesStudio.Services
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectedLists();
    }
}
