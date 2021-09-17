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
    public class MediaService
    {
        private readonly Guid _userId;
        private readonly string[] _categories = { "Sent", "Recieved" };

        public MediaService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNewMedia(MediaCreate model, string userEmail)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity =
                    new Media()
                    {
                        MediaType = model.MediaType,
                        Title = model.Title,
                        Author = model.Authors,
                        YearReleased = model.YearReleased,
                        Genre = model.Genre,
                        Rating = model.Rating,
                        Quantity = model.Quantity,
                        InstockQuantity = model.Quantity,
                        DateAdded = DateTime.Now,
                        LastUpdated = DateTime.Now,
                        AddedBy = userEmail,
                        LastUpdatedBy = userEmail
                    };

                ctx.Medias.Add(entity);

                return ctx.SaveChanges() > 0;
            }
        }

        public List<MediaList> GetAllMedias()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return null;
                }

                List<MediaList> allMediasList = new List<MediaList>();

                foreach (Media media in medias)
                {

                    MediaList mediaListToAdd = new MediaList
                    {
                        MediaId = media.Media_Id,
                        MediaType = media.MediaType,
                        Title = media.Title,
                        Author = media.Author,
                        YearReleased = media.YearReleased,
                        Genre = media.Genre,
                        Rating = media.Rating,
                        OverallQuantity = media.Quantity,
                        InstockQuantity = media.InstockQuantity,
                        DateAdded = media.DateAdded,
                        LastUpdated = media.LastUpdated,
                        AddedBy = media.AddedBy,
                        LastUpdatedBy = media.LastUpdatedBy
                    };

                    allMediasList.Add(mediaListToAdd);

                }

                return allMediasList;
            }
        }

        public List<MediaList> GetMediaByGenre(GenreTypes genreType)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return null;
                }

                List<MediaList> genreMediasList = new List<MediaList>();

                foreach (Media media in medias)
                {
                    if (media.Genre == genreType)
                    {
                        MediaList mediaListToAdd = new MediaList
                        {
                            MediaId = media.Media_Id,
                            MediaType = media.MediaType,
                            Title = media.Title,
                            Author = media.Author,
                            YearReleased = media.YearReleased,
                            Genre = media.Genre,
                            Rating = media.Rating,
                            OverallQuantity = media.Quantity,
                            InstockQuantity = media.InstockQuantity,
                            DateAdded = media.DateAdded,
                            LastUpdated = media.LastUpdated,
                            AddedBy = media.AddedBy,
                            LastUpdatedBy = media.LastUpdatedBy
                        };

                        genreMediasList.Add(mediaListToAdd);
                    }
                }

                return genreMediasList;
            }
        }

        public List<MediaList> GetMediaByAuthor(string author)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return null;
                }

                List<MediaList> authorMediasList = new List<MediaList>();

                foreach (Media media in medias)
                {
                    if (media.Author.ToLower() == author.ToLower())
                    {
                        MediaList mediaListToAdd = new MediaList
                        {
                            MediaId = media.Media_Id,
                            MediaType = media.MediaType,
                            Title = media.Title,
                            Author = media.Author,
                            YearReleased = media.YearReleased,
                            Genre = media.Genre,
                            Rating = media.Rating,
                            OverallQuantity = media.Quantity,
                            InstockQuantity = media.InstockQuantity,
                            DateAdded = media.DateAdded,
                            LastUpdated = media.LastUpdated,
                            AddedBy = media.AddedBy,
                            LastUpdatedBy = media.LastUpdatedBy
                        };

                        authorMediasList.Add(mediaListToAdd);
                    }
                }

                return authorMediasList;
            }
        }

        public List<MediaList> GetMediaByType(MediaTypes type)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return null;
                }

                List<MediaList> mediaTypesMediasList = new List<MediaList>();

                foreach (Media media in medias)
                {
                    if (media.MediaType == type)
                    {
                        MediaList mediaListToAdd = new MediaList
                        {
                            MediaId = media.Media_Id,
                            MediaType = media.MediaType,
                            Title = media.Title,
                            Author = media.Author,
                            YearReleased = media.YearReleased,
                            Genre = media.Genre,
                            Rating = media.Rating,
                            OverallQuantity = media.Quantity,
                            InstockQuantity = media.InstockQuantity,
                            DateAdded = media.DateAdded,
                            LastUpdated = media.LastUpdated,
                            AddedBy = media.AddedBy,
                            LastUpdatedBy = media.LastUpdatedBy
                        };

                        mediaTypesMediasList.Add(mediaListToAdd);
                    }
                }

                return mediaTypesMediasList;
            }
        }

        public List<MediaList> GetMediaByRating(RatingTypes rating)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return null;
                }

                List<MediaList> mediaRatingsMediasList = new List<MediaList>();

                foreach (Media media in medias)
                {
                    if (media.Rating == rating)
                    {
                        MediaList mediaListToAdd = new MediaList
                        {
                            MediaId = media.Media_Id,
                            MediaType = media.MediaType,
                            Title = media.Title,
                            Author = media.Author,
                            YearReleased = media.YearReleased,
                            Genre = media.Genre,
                            Rating = media.Rating,
                            OverallQuantity = media.Quantity,
                            InstockQuantity = media.InstockQuantity,
                            DateAdded = media.DateAdded,
                            LastUpdated = media.LastUpdated,
                            AddedBy = media.AddedBy,
                            LastUpdatedBy = media.LastUpdatedBy
                        };

                        mediaRatingsMediasList.Add(mediaListToAdd);
                    }
                }

                return mediaRatingsMediasList;
            }
        }

        public List<MediaList> GetMediaByDateRange(DateTime from, DateTime to)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var medias = ctx.Medias.ToList();

                if (medias is null)
                {
                    return null;
                }

                List<MediaList> inRangeMediasList = new List<MediaList>();

                foreach (Media media in medias)
                {
                    if (media.YearReleased >= from && media.YearReleased <= to)
                    {
                        MediaList mediaListToAdd = new MediaList
                        {
                            MediaId = media.Media_Id,
                            MediaType = media.MediaType,
                            Title = media.Title,
                            Author = media.Author,
                            YearReleased = media.YearReleased,
                            Genre = media.Genre,
                            Rating = media.Rating,
                            OverallQuantity = media.Quantity,
                            InstockQuantity = media.InstockQuantity,
                            DateAdded = media.DateAdded,
                            LastUpdated = media.LastUpdated,
                            AddedBy = media.AddedBy,
                            LastUpdatedBy = media.LastUpdatedBy
                        };

                        inRangeMediasList.Add(mediaListToAdd);
                    }
                }

                return inRangeMediasList;
            }
        }

        public bool UpdateMediaQuantity(MediaQuantityUpdate model, string userEmail)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Medias
                    .Single(e => e.Media_Id == model.MediaIdToUpdate);

                entity.Quantity = model.NewQuantity;
                entity.LastUpdated = DateTime.Now;
                entity.LastUpdatedBy = userEmail;

                return ctx.SaveChanges() == 1;
            };

        }

        public bool DeleteMedia(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allMedia = ctx.Medias.ToList();

                Media mediaToDelete = new Media();

                foreach (Media  media in allMedia)
                {
                    if (ID == media.Media_Id)
                    {
                        mediaToDelete = media;
                    }
                }

                if (mediaToDelete is null)
                {
                    return false;
                }

                ctx.Medias.Remove(mediaToDelete);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
