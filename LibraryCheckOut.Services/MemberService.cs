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
    }
}
