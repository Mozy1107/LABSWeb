using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Models
{
    /// <summary>
    /// Базовый класс для всех персон в системе образования
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "ФИО обязательно для заполнения")]
        [StringLength(100)]
        [Display(Name = "ФИО")]
        public string Name { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
    }

    /// <summary>
    /// Модель данных для абитуриентов
    /// </summary>
    public class Applicant : Person
    {
        [Range(0, 400, ErrorMessage = "Баллы должны быть в диапазоне от 0 до 400")]
        [Display(Name = "Баллы ЕГЭ")]
        public int Score { get; set; }
    }

    /// <summary>
    /// Модель данных для студентов
    /// </summary>
    public class Student : Person
    {
        [Range(1, 6)]
        [Display(Name = "Курс обучения")]
        public int Course { get; set; }
        
        [Required]
        [StringLength(20)]
        [Display(Name = "Номер группы")]
        public string Group { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Факультет")]
        public string Faculty { get; set; } = string.Empty;
    }

    /// <summary>
    /// Модель данных для преподавательского состава
    /// </summary>
    public class Teacher : Person
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Ученая степень / Должность")]
        public string Position { get; set; } = string.Empty;
        
        [Required]
        [StringLength(100)]
        [Display(Name = "Кафедра")]
        public string Department { get; set; } = string.Empty;
    }
}