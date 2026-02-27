using System.ComponentModel.DataAnnotations;

namespace Rabota2.Models
{
    public class Administraciya : Kadry
    {
        [Required(ErrorMessage = "Должность обязательна")]
        [StringLength(100, ErrorMessage = "Должность не должна превышать 100 символов")]
        [Display(Name = "Должность")]
        public string Dolzhnost { get; set; } = string.Empty;
    }
}
