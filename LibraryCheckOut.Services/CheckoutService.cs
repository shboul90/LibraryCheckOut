using LibraryCheckOut.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Services
{
    class CheckoutService
    {
        private readonly Guid _userID;

        public CheckoutService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateCheckout(Checkout model)
        {
            var entity = new Checkout()
            {
                ID = _userID,
                Checkout_Id = model.Checkout_Id,
                CheckoutDate = DateTime.Now,
                Member_Id = model.Member_Id,
                ListOfItems = model.ListOfItems,
                TotalNumberOfItems = model.TotalNumberOfItems
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Checkouts.Add(model);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<Checkout> GetAllCheckouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Checkouts
                                .Where(e => e.ID == _userID)
                                .Select(e => new Checkout
                                {
                                    Checkout_Id = e.Checkout_Id,
                                    Member_Id = e.Member_Id,
                                    CheckoutDate = e.CheckoutDate,
                                    TotalNumberOfItems = e.TotalNumberOfItems
                                });
                return query.ToList();

            }
        }
    }
}
