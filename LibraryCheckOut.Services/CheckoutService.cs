using LibraryCheckOut.Data;
using LibraryCheckOut.Models.ENUMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCheckOut.Services
{
    public class CheckoutService
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
                Member_id = model.Member_id,
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
                                    Member_id = e.Member_id,
                                    CheckoutDate = e.CheckoutDate,
                                    TotalNumberOfItems = e.TotalNumberOfItems
                                });
                return query.ToList();

            }
        }

        //public Checkout GetCheckoutsByLastName(string lastName)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity = ctx
        //                        .Checkouts
        //                        .Single(e => e. == lastName && e. == );
        //        return
        //          new Checkout
        //          {

        //          };
        //    }
        //}

        public Checkout GetCheckoutsByMediaType(MediaTypes mediaType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Checkouts
                                .Single(e => e.Media.MediaType == mediaType && e.ID == _userID);
                return
                    new Checkout
                    {
                        Checkout_Id = entity.Checkout_Id,
                        Member_id = entity.Member_id,
                        CheckoutDate = entity.CheckoutDate,
                        TotalNumberOfItems = entity.TotalNumberOfItems,
                    };
            }
        }

        public Checkout GetCheckoutsByMediaTitle(string mediaTitle)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Checkouts
                                .Single(e => e.Media.Title == mediaTitle && e.ID == _userID);
                return
                    new Checkout
                    {
                        Checkout_Id = entity.Checkout_Id,
                        Member_id = entity.Member_id,
                        CheckoutDate = entity.CheckoutDate,
                        TotalNumberOfItems = entity.TotalNumberOfItems,
                    };
            }
        }

        public Checkout GetCheckoutsByDateOfTransaction(DateTime dateOfTransaction)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Checkouts
                                .Single(e => e.CheckoutDate == dateOfTransaction && e.ID == _userID);
                return
                    new Checkout
                    {
                        Checkout_Id = entity.Checkout_Id,
                        Member_id = entity.Member_id,
                        CheckoutDate = entity.CheckoutDate,
                        TotalNumberOfItems = entity.TotalNumberOfItems,
                    };
            }
        }
    }
}
