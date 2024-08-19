namespace GameStudio.Attributes
{
    public class AllowedExtensionAttributes : ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public AllowedExtensionAttributes(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extensions = Path.GetExtension(file.FileName);
                var IsAllowed = _allowedExtensions.Split(',').Contains(extensions, StringComparer.OrdinalIgnoreCase);
                if (!IsAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtensions} are allowed !");
                }
            }

            return ValidationResult.Success;

        }
    }
}
