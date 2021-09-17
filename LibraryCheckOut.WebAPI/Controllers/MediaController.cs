using LibraryCheckOut.Models;
using LibraryCheckOut.Models.ENUMs;
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
    public class MediaController : ApiController
    {
        private MediaService StartMediaService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var emailService = new MediaService(userId);
            return emailService;
        }

        [HttpPost]
        [Route("api/Media")]
        public IHttpActionResult Post([FromBody] MediaCreate media)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = StartMediaService();
            var userEmail = User.Identity.GetUserName();

            if (!service.CreateNewMedia(media, userEmail))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpGet]
        [Route("api/Media")]
        public IHttpActionResult GetAllMedia()
        {

            var service = StartMediaService();
            var medias = service.GetAllMedias();

            if (medias is null)
            {
                return BadRequest("No media exists in the database!");
            }

            if (medias.Count == 0)
            {
                return BadRequest("No medias exist in the database!");
            }

            return Ok(medias);
        }

        [HttpGet]
        [Route("api/Media/Genre")]
        public IHttpActionResult GetAllMediaByGenre(GenreTypes genreType)
        {

            var service = StartMediaService();
            var medias = service.GetMediaByGenre(genreType);

            if (medias is null)
            {
                return BadRequest("No media exists in the database!");
            }

            if (medias.Count == 0)
            {
                return BadRequest("No medias by that genre exist in the database!");
            }

            return Ok(medias);
        }

        [HttpGet]
        [Route("api/Media/Author")]
        public IHttpActionResult GetAllMediaByAuthor(string author)
        {

            var service = StartMediaService();
            var medias = service.GetMediaByAuthor(author);

            if (medias is null)
            {
                return BadRequest("No media exists in the database!");
            }

            if (medias.Count == 0)
            {
                return BadRequest("No medias by that author exist in the database!");
            }

            return Ok(medias);
        }

        [HttpGet]
        [Route("api/Media/Type")]
        public IHttpActionResult GetAllMediaByType(MediaTypes type)
        {

            var service = StartMediaService();
            var medias = service.GetMediaByType(type);

            if (medias is null)
            {
                return BadRequest("No media exists in the database!");
            }

            if (medias.Count == 0)
            {
                return BadRequest("No medias by that type exist in the database!");
            }

            return Ok(medias);
        }

        [HttpGet]
        [Route("api/Media/Rating")]
        public IHttpActionResult GetAllMediaByRating(RatingTypes rating)
        {

            var service = StartMediaService();
            var medias = service.GetMediaByRating(rating);

            if (medias is null)
            {
                return BadRequest("No media exists in the database!");
            }

            if (medias.Count == 0)
            {
                return BadRequest("No medias by that type exist in the database!");
            }

            return Ok(medias);
        }

        [HttpGet]
        [Route("api/Media/YearReleasedRange")]
        public IHttpActionResult GetAllMediaByDateRange(DateTime from, DateTime to)
        {

            var service = StartMediaService();
            var medias = service.GetMediaByDateRange(from, to);

            if (medias is null)
            {
                return BadRequest("No media exists in the database!");
            }

            if (medias.Count == 0)
            {
                return BadRequest("No medias by that type exist in the database!");
            }

            return Ok(medias);
        }

        [HttpPut]
        [Route("api/Media")]
        public IHttpActionResult Put([FromBody] MediaQuantityUpdate mediaQuantityUpdates)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = StartMediaService();
            var userEmail = User.Identity.GetUserName();

            if (!service.UpdateMediaQuantity(mediaQuantityUpdates, userEmail))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("api/Media")]
        public IHttpActionResult DeleteEmail([FromUri] int mediaId)
        {

            var service = StartMediaService();

            if (!service.DeleteMedia(mediaId))
            {
                return InternalServerError();
            }

            return Ok();

        }
    }
}
