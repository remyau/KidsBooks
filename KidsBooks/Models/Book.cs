using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KidsBooks.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(75,ErrorMessage ="Name should not exceed 75 characters")]
        public String Name { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="Author should not exceed 50 characters")]
        public String Author { get; set; }

        [Required]
        [MaxLength (50,ErrorMessage ="Publisher should not exceed 50 characters")]
        public String Publisher { get; set; } 
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [Display(Name="Published Date")]
        public DateTime Date_Published { get; set; }

        public DateTime Date_Added { get; set; }

        [MaxLength(300,ErrorMessage ="Length should not exceed 300")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        
        public Category category { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name="Language")]
        public Languages Lang { get; set; }
    }
}
