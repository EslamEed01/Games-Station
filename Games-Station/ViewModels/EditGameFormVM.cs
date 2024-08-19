using GameStudio.Attributes;

namespace Games_Station.ViewModels
{
    public class EditGameFormVM : GameFormVM
    {

        public int id { get; set; }
        public string? CurrentCover { get; set; }

        [AllowedExtensionAttributes(FileSettings.AllowedFileExtension), MaxFileSize(FileSettings.MaxFileSizeINByte)]
        public IFormFile? Cover { get; set; } = default!;


    }
}
