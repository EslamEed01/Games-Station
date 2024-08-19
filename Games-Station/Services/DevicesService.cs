

using GamesStudio.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamesStudio.Services
{
    public class DevicesServices : IDevicesService
    {
        private readonly ApplicationDbContext _DbContext;

        public DevicesServices(ApplicationDbContext context)
        {
            _DbContext = context;
        }

        public IEnumerable<SelectListItem> GetDevicesList()
        {
            return _DbContext.Devices
                .AsNoTracking()
                .Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .ToList();
        }
    }
}
