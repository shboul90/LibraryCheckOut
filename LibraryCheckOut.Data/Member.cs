using LibraryCheckOut.Models.ENUMs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Data
{
    public class Member
    {
        [Key]
        public int Member_id { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime DateOfMembership { get; set; }
        [Required]
        public RatingTypes MembershipRating { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
