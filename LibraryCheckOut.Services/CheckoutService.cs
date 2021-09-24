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

        public List<CheckoutList> GetAllCheckouts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Checkouts
                                .Where(e => e.ID == _userID)
                                .Select(e => new CheckoutList
                                {
                                    Checkout_Id = e.Checkout_Id,
                                    Member_id = e.Member_id,
                                    CheckoutDate = e.CheckoutDate,
                                }
                                );
                return query.ToList();
            }
        }

        public IEnumerable<CheckoutList> GetCheckoutsByLastName(string lastName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var listItemToShow = ctx.Checkouts
                                        .Where(e => e.Member.LastName == lastName)
                                        .Select(e => new CheckoutList 
                                        { 
                                            Checkout_Id = e.Checkout_Id,
                                            CheckoutDate = e.CheckoutDate,
                                            Member_id = e.Member_id,
                                        }
                                        );

                    return listItemToShow.ToList();
            }
        }

        public List<CheckoutList> GetCheckoutsByMediaType(MediaTypes mediaType)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx
                                .Checkouts
                                .Where(e => e.Media.MediaType == mediaType)
                                .Select(e => new CheckoutList
                                {
                                    Checkout_Id = e.Checkout_Id,
                                    Member_id = e.Member_id,
                                    CheckoutDate = e.CheckoutDate,
                                }
                                );

                return entity.ToList();
            }
        }

        public IEnumerable<CheckoutList> GetCheckoutsByMediaTitle(string mediaTitle)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var listItemToShow = ctx.Checkouts
                                        .Where(e => e.Media.Title == mediaTitle)
                                        .Select(e => new CheckoutList
                                        {
                                            Checkout_Id = e.Checkout_Id,
                                            CheckoutDate = e.CheckoutDate,
                                            Member_id = e.Member_id,
                                        }
                                        );

                return listItemToShow.ToList();
            }
        }

        public IEnumerable<CheckoutList> GetCheckoutsByDateOfTransaction(DateTime dateOfTransaction)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Checkouts
                                .Where(e => e.CheckoutDate == dateOfTransaction)
                                .Select(e => new CheckoutList
                                 {
                                     Checkout_Id = e.Checkout_Id,
                                     Member_id = e.Member_id,
                                     CheckoutDate = e.CheckoutDate,
                                 });

                return entity.ToList();
            }
        }
    }
}
