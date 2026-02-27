using System.ComponentModel.DataAnnotations;

namespace Rabota1.Models
{
    public class Worker
    {
        public int Id { get; set; }
        
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "ФИО обязательно")]
        [Display(Name = "ФИО")]
        public string FullName { get; set; } = string.Empty;
        
        [StringLength(50)]
        [Required(ErrorMessage = "Должность обязательна")]
        [Display(Name = "Должность")]
        public string Position { get; set; } = string.Empty;
        
        [Range(0, 100, ErrorMessage = "Стаж должен быть от 0 до 100")]
        [Display(Name = "Стаж (лет)")]
        public int Experience { get; set; }
        
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
