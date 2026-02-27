using System.ComponentModel.DataAnnotations;

namespace Rabota2.Models
{
    public class Inzhener : Kadry
    {
        [Required(ErrorMessage = "Квалификация обязательна")]
        [StringLength(100, ErrorMessage = "Квалификация не должна превышать 100 символов")]
        [Display(Name = "Квалификация")]
        public string Kvalifikaciya { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Подразделение обязательно")]
        [StringLength(100, ErrorMessage = "Название подразделения не должно превышать 100 символов")]
        [Display(Name = "Подразделение")]
        public string Podrazdelenie { get; set; } = string.Empty;
    }
}
