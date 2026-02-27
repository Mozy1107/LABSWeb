using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabota1.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        [StringLength(50, MinimumLength = 2)]
        [Required(ErrorMessage = "Марка обязательна")]
        [Display(Name = "Марка")]
        public string Brand { get; set; } = string.Empty;

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Модель обязательна")]
        [Display(Name = "Модель")]
        public string Model { get; set; } = string.Empty;
        
        [Display(Name = "Год выпуска")]
        [Range(1900, 2100, ErrorMessage = "Год должен быть от 1900 до 2100")]
        [Required(ErrorMessage = "Год выпуска обязателен")]
        public int Year { get; set; }
        
        [RegularExpression(@"^[A-ZА-Я]+[a-zA-Zа-яА-Я\s]*$", ErrorMessage = "Тип должен начинаться с заглавной буквы")]
        [Required(ErrorMessage = "Тип автомобиля обязателен")]
        [StringLength(30)]
        [Display(Name = "Тип")]
        public string CarType { get; set; } = string.Empty;
        
        [Range(100000, 50000000, ErrorMessage = "Цена должна быть от 100000 до 50000000")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Цена (руб.)")]
        public decimal Price { get; set; }
    }
}
