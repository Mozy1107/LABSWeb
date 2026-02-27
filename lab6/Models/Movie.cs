using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }
        
        [Display(Name = "Дата выхода в прокат")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        
        [RegularExpression(@"^[A-ZА-Я]+[a-zA-Zа-яА-Я\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }
        
        [Range(1, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        [RegularExpression(@"^[A-ZА-Я]+[a-zA-Zа-яА-Я0-9""'\s-]*$")]
        [StringLength(10)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
