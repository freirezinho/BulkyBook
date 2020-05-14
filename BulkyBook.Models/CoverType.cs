using System;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class CoverType
    {
        public CoverType()
        {
        }
        [Key]
        public int Id { get; set; }
        [Display(Name="Cover Type")]
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
