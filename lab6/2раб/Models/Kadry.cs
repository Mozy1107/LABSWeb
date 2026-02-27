using System.ComponentModel.DataAnnotations;

namespace Rabota2.Models
{
    public class Kadry
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 100 символов")]
        [Display(Name = "Имя")]
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Тип сотрудника")]
        public string EmployeeType { get; set; } = string.Empty;
    }
}
