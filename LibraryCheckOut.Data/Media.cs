using LibraryCheckOut.Models.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Data
{
    public class Media
    {
        [Key]
        public int Media_Id { get; set; }

        public MediaTypes MediaType { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime YearReleased { get; set; }

        public GenreTypes Genre { get; set; }

        public RatingTypes Rating { get; set; }

        public int Quantity { get; set; }

        public int InstockQuantity { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime LastUpdated { get; set; }

        public string AddedBy { get; set; }

        public string LastUpdatedBy { get; set; }

    }
}
