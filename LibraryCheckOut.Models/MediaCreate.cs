using LibraryCheckOut.Models.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Models
{
    public class MediaCreate
    {
        [Required]
        public MediaTypes MediaType { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field, limit to 100 characters!")]
        public string Title { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 characters.")]
        [MaxLength(60, ErrorMessage = "There are too many characters in this field, limit to 60 characters!")]
        public string Authors { get; set; }

        [Required]
        public DateTime YearReleased { get; set; }

        [Required]
        public GenreTypes Genre { get; set; }

        [Required]
        public RatingTypes Rating { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
