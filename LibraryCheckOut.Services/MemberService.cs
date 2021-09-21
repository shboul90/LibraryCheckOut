using LibraryCheckOut.Data;
using LibraryCheckOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Services
{
    public class MemberService
    {
        private readonly Guid _userId;

        public MemberService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMember(MemberCreate model)
        {
            var entity =
                new Member()
                {
                    OwnerId = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip,
                    PhoneNumber = model.PhoneNumber,
                    DateOfMembership = model.DateOfMembership,
                    MembershipRating = model.MembershipRating,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Members.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MemberListItem> GetMembers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Members
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MemberListItem
                                {
                                    MemberId = e.Member_id,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }

        public MemberDetail GetMemberById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.Member_id == id && e.OwnerId == _userId);
                return
                    new MemberDetail
                    {
                        Member_id = entity.Member_id,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip,
                        PhoneNumber = entity.PhoneNumber,
                        DateOfMembership = entity.DateOfMembership,
                        MembershipRating = entity.MembershipRating,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateMember(MemberEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.Member_id == model.Memberid && e.OwnerId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                entity.PhoneNumber = model.PhoneNumber;
                entity.DateOfMembership = model.DateOfMembership;
                entity.MembershipRating = model.MembershipRating;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMember(int memberId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Members
                        .Single(e => e.Member_id == memberId && e.OwnerId == _userId);

                ctx.Members.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
