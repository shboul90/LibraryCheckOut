using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Models
{
    public class CheckoutList // What we want the user to see
    {
        [Required]
        public int Checkout_Id { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime CheckoutDueDate
        {
            get
            {
                DateTime dueDate = CheckoutDate.AddDays(7);
                return dueDate;
            }
        }
        public int Member_id { get; set; }
        public IEnumerable<int> ListOfItems { get; set; }
        }
    }
