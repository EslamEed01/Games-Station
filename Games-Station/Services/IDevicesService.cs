using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamesStudio.Services
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetDevicesList();
    }
}
