using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Data
{
    public class Checkout
    {
        [Key]
        [Required]
        public Guid ID { get; set; }
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
        [ForeignKey(nameof(Member))]
        [Required]
        public int Member_Id { get; set; }

        [ForeignKey(nameof(Media))]
        [Required]
        public List<Media> ListOfItems { get; set; }
        public int TotalNumberOfItems { get; set; }

    }
}
