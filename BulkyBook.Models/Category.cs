using System;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        public Category()
        {
        }
        [Key]
        public int Id { get; set; }
        [Display(Name="CategoryName")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
