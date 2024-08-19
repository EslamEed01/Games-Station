
using Games_Station.ViewModels;
using GameStudio.Attributes;
using GameStudio.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace GamesStudio.ViewModels
{
    public class CreateGameFormVM: GameFormVM
    {


        //[MaxLength(500)]
        [AllowedExtensionAttributes(FileSettings.AllowedFileExtension), MaxFileSize(FileSettings.MaxFileSizeINByte)]

        public IFormFile Cover { get; set; } = default!;
    }
}
