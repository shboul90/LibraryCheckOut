using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace LibraryCheckOut.WebAPI.Controllers
{
    public class CheckoutController : ApiController
    {
        // Post Checkout
        // Get All Checkout Transactions
        // Get All Checkout Transactions By Member Last Name
        // Get All Checkout Transactions By Media Type
        public IHttpActionResult Index()
        {
            return View();
        }
    }
}