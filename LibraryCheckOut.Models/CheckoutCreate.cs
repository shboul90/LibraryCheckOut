using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Models
{
    public class CheckoutCreate //what we want the user to provide
    {
        [Required]
        public int Member_id { get; set; }
        public List<int> MediaList { get; set; }
        public int TotalNumberOfItems { get; set; }
    }
}
