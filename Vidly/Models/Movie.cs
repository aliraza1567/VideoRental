using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models.Validations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Date Release")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Quantity In Stock")]
        [Required]
        [StockNumberValidation]
        public int NumberInStock { get; set; }
    }
}