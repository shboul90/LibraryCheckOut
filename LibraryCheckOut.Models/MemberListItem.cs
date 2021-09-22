using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Models
{
    public class MemberListItem
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name="Member Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
