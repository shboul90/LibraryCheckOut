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
        public int Member_id { get; set; }
        public virtual Member Member { get; set; }

        [ForeignKey(nameof(Media))]
        [Required]
        public List<int> ListOfItems { get; set; }
        public virtual Media Media { get; set; }

        public int TotalNumberOfItems { get; set; }

    }
}
