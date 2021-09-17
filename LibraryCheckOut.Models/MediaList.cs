using LibraryCheckOut.Models.ENUMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Models
{
    public class MediaList
    {
        public int MediaId { get; set; }

        public MediaTypes MediaType { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime YearReleased { get; set; }

        public GenreTypes Genre { get; set; }

        public RatingTypes Rating { get; set; }

        public int OverallQuantity { get; set; }

        public int InstockQuantity { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime LastUpdated { get; set; }

        public string AddedBy { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
