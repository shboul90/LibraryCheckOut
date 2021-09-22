using LibraryCheckOut.Data;
using LibraryCheckOut.Models;
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

        public bool CreateCheckout(CheckoutCreate model)
        {
            var entity = new Checkout()
            {
                ID = _userID,
                CheckoutDate = DateTime.Now,
                Member_id = model.Member_id,
                TotalNumberOfItems = model.TotalNumberOfItems
            };

            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return false;
                }

                foreach (int mediaListItem in model.MediaList)
                {
                    var mediaToAdd = medias.Single(e => e.Media_Id == mediaListItem); //found media item. Will throw an error with no media in database
                    entity.MediaCollection.Add(mediaToAdd); //added it to list
                }

                ctx.Checkouts.Add(entity);
                return ctx.SaveChanges() >= 1; //method that saves changes through database. If no rows were changed, it would return an error
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
                                .Single(e => e.ID == _userID);
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
                                .Single(e =>  e.ID == _userID);
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
