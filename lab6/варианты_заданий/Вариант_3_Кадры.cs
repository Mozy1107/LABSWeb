using System.ComponentModel.DataAnnotations;

namespace RazorPagesApp.Models
{
    /// <summary>
    /// Базовый класс сотрудника предприятия
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Поле ФИО обязательно")]
        [StringLength(100, MinimumLength = 3)]
        [Display(Name = "ФИО сотрудника")]
        public string Name { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }
    }

    /// <summary>
    /// Модель данных: Рабочий персонал
    /// </summary>
    public class Worker : Person
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Специальность / Разряд")]
        public string Specialty { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Производственный цех")]
        public string Workshop { get; set; } = string.Empty;
    }

    /// <summary>
    /// Модель данных: Инженерно-технический состав
    /// </summary>
    public class Engineer : Person
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Уровень квалификации")]
        public string Qualification { get; set; } = string.Empty;
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Отдел / Подразделение")]
        public string Department { get; set; } = string.Empty;
    }

    /// <summary>
    /// Модель данных: Администрация и руководство
    /// </summary>
    public class Administration : Person
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Занимаемая должность")]
        public string Position { get; set; } = string.Empty;

        [Display(Name = "Срок полномочий (лет)")]
        public int Tenure { get; set; }
    }
}