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
        public Checkout()
        {
            this.MediaCollection = new HashSet<Media>();
        }
        [Key]
        public int Checkout_Id { get; set; }
        [Required]
        public Guid ID { get; set; }
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

        //[ForeignKey(nameof(Media))] ---- foreign keys used when there is one item being referenced
       // [Required]
       // public List<int> ListOfItems { get; set; }

       // public virtual Media Media { get; set; }
        public virtual ICollection<Media> MediaCollection { get; set; }
        public int TotalNumberOfItems { get; set; }

    }
}
