using LibraryCheckOut.Data;
using LibraryCheckOut.Models;
using LibraryCheckOut.Models.ENUMs;
using LibraryCheckOut.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LibraryCheckOut.WebAPI.Controllers
{
    public class CheckoutController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Post(CheckoutCreate transaction)
        {
            if (transaction is null)
                return BadRequest("Cannot be null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCheckoutService();

            if (!service.CreateCheckout(transaction))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        //[Route("Checkout/GetAll")]
        public IHttpActionResult GetAll()
        {
            CheckoutService checkoutService = CreateCheckoutService();
            var checkouts = checkoutService.GetAllCheckouts();
            return Ok(checkouts);
        }

        [HttpGet]
        public IHttpActionResult GetByLastName(string lastName)
        {
            CheckoutService checkoutService = CreateCheckoutService();
            var checkouts = checkoutService.GetCheckoutsByLastName(lastName);
            return Ok(checkouts);
        }

        [HttpGet]
        public IHttpActionResult GetByMediaType(MediaTypes mediaType)
        {
            CheckoutService checkoutService = CreateCheckoutService();
            var checkouts = checkoutService.GetCheckoutsByMediaType(mediaType);
            return Ok(checkouts);
        }

        [HttpGet]
        public IHttpActionResult GetByMediaTitle(string mediaTitle)
        {
            CheckoutService checkoutService = CreateCheckoutService();
            var checkouts = checkoutService.GetCheckoutsByMediaTitle(mediaTitle);
            return Ok(checkouts);
        }

        [HttpGet]
        public IHttpActionResult GetByDateOfCheckout(DateTime dateTime)
        {
            CheckoutService checkoutService = CreateCheckoutService();
            var checkouts = checkoutService.GetCheckoutsByDateOfTransaction(dateTime);
            return Ok(checkouts);
        }

        private CheckoutService CreateCheckoutService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var checkoutService = new CheckoutService(userId);
            return checkoutService;
        }

    }
}