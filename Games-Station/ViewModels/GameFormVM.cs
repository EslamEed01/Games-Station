namespace Games_Station.ViewModels
{
    public class GameFormVM
    {

        [MaxLength(500)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(3000)]
        public string Description { get; set; } = string.Empty;


        public IFormFile Cover { get; set; } = default!;

        [Display(Name = "Category")]
        public int CategoriesId { get; set; }


        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevices { get; set; } = default!;

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();// there is another way like viewbag
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
