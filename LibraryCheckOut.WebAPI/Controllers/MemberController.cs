using LibraryCheckOut.Models;
using LibraryCheckOut.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryCheckOut.WebAPI.Controllers
{
    [Authorize]
    public class MemberController : ApiController
    {
        public IHttpActionResult Get()
        {
            MemberService memberService = CreateMemberService();
            var members = memberService.GetMembers();
            return Ok(members);
        }

        public IHttpActionResult Post(MemberCreate member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMemberService();

            if (!service.CreateMember(member))
                return InternalServerError();

            return Ok();
        }
        private MemberService CreateMemberService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var memberService = new MemberService(userId);
            return memberService;
        }
    }
}
