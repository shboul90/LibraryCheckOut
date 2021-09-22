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

        public IHttpActionResult Get(int id)
        {
            MemberService memberService = CreateMemberService();
            var member = memberService.GetMemberById(id);
            return Ok(member);
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

        public IHttpActionResult Put (MemberEdit member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMemberService();

            if (!service.UpdateMember(member))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete (int id)
        {
            var service = CreateMemberService();

            if (!service.DeleteMember(id))
                return InternalServerError();

            return Ok();
        }
    }
}
