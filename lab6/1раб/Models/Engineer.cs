using System.ComponentModel.DataAnnotations;

namespace Rabota1.Models
{
    public class Engineer
    {
        public int Id { get; set; }
        
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "ФИО обязательно")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;
        
        [StringLength(100)]
        [Required(ErrorMessage = "Специальность обязательна")]
        [Display(Name = "Специальность")]
        public string Specialization { get; set; } = string.Empty;
        
        [Range(0, 100, ErrorMessage = "Квалификация должна быть от 0 до 100")]
        [Display(Name = "Уровень квалификации")]
        public int QualificationLevel { get; set; }
        
        [StringLength(50)]
        [Display(Name = "Категория")]
        public string? Category { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string? PhoneNumber { get; set; }
        
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string? Email { get; set; }
        
        [Display(Name = "Дата приема")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }
    }
}
