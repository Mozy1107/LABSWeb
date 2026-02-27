using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Models
{
    /// <summary>
    /// Базовый класс для любого печатного издания в фонде
    /// </summary>
    public class Publication
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Необходимо указать название издания")]
        [StringLength(200)]
        [Display(Name = "Название издания")]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Издательство")]
        public string Publisher { get; set; } = string.Empty;
        
        [Range(1500, 2100, ErrorMessage = "Укажите корректный год издания")]
        [Display(Name = "Год выпуска")]
        public int Year { get; set; }
    }

    /// <summary>
    /// Модель данных: Периодические издания (Журналы)
    /// </summary>
    public class Magazine : Publication
    {
        [Range(1, 1000)]
        [Display(Name = "Номер выпуска")]
        public int Number { get; set; }
        
        [Range(1, 12)]
        [Display(Name = "Месяц выхода")]
        public int Month { get; set; }
    }

    /// <summary>
    /// Модель данных: Книги
    /// </summary>
    public class Book : Publication
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Автор (ФИО)")]
        public string Author { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Жанр / Тематика")]
        public string Theme { get; set; } = string.Empty;
        
        [Range(1, 10000)]
        [Display(Name = "Кол-во страниц")]
        public int Pages { get; set; }
    }

    /// <summary>
    /// Модель данных: Учебная литература
    /// </summary>
    public class Textbook : Book
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Предмет / Дисциплина")]
        public string Subject { get; set; } = string.Empty;

        [Range(1, 11)]
        [Display(Name = "Класс / Рекомендованный курс")]
        public int GradeLevel { get; set; }
    }
}