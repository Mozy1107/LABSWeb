using System.ComponentModel.DataAnnotations;

namespace Rabota2.Models
{
    public class Rabochiy : Kadry
    {
        [Required(ErrorMessage = "Специальность обязательна")]
        [StringLength(100, ErrorMessage = "Специальность не должна превышать 100 символов")]
        [Display(Name = "Специальность")]
        public string Specialnost { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Цех обязателен")]
        [StringLength(50, ErrorMessage = "Название цеха не должно превышать 50 символов")]
        [Display(Name = "Цех")]
        public string Ceh { get; set; } = string.Empty;
    }
}
