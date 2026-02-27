using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rabota1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Название обязательно")]
        [Display(Name = "Название")]
        public string Title { get; set; } = string.Empty;
        
        [Display(Name = "Дата выпуска")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата выпуска обязательна")]
        public DateTime ReleaseDate { get; set; }
        
        [RegularExpression(@"^[A-ZА-Я]+[a-zA-Zа-яА-Я\s]*$", ErrorMessage = "Жанр должен начинаться с заглавной буквы")]
        [Required(ErrorMessage = "Жанр обязателен")]
        [StringLength(30)]
        [Display(Name = "Жанр")]
        public string Genre { get; set; } = string.Empty;
        
        [Range(1, 10000, ErrorMessage = "Цена должна быть от 1 до 10000")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        
        [RegularExpression(@"^[A-ZА-Я0-9]+[a-zA-Zа-яА-Я0-9\+\s-]*$")]
        [StringLength(10)]
        [Required(ErrorMessage = "Рейтинг обязателен")]
        [Display(Name = "Рейтинг")]
        public string Rating { get; set; } = string.Empty;
    }
}
