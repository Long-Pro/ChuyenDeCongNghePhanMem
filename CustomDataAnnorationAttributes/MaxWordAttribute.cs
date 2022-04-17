using System.ComponentModel.DataAnnotations;
namespace ChuyenDeCongNghePhanMem.CustomDataAnnorationAttributes
{
    public class MaxWordAttribute : ValidationAttribute

    {
        private readonly int _maxWords;
        public MaxWordAttribute(int maxWords)
            : base("{0} has to many words.")
        {
            _maxWords = maxWords;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
            var textValue = value.ToString();
            if (textValue.Split(' ').Length <= _maxWords) return ValidationResult.Success;
            var errorMessage = FormatErrorMessage((validationContext.DisplayName));
            return new ValidationResult(errorMessage);
        }
    }
}
