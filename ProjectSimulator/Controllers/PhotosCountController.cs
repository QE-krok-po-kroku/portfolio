using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;
using System.Collections.Generic;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/portfolio/photoscount")]
    public class PhotosCountController : ApiController
    {
        readonly PhotoDao _dao = new PhotoDao();

        [Route("")]
        [HttpGet]
        public Count GetPhotosCount()
        {

            IEnumerable<Photo> countCollection = _dao.GetPhotos();
            int photos = 0;

            foreach (Photo colectPhoto in countCollection)
            {
                if (!colectPhoto.Grade.ToLower().Equals("very_bad"))
                {
                    photos++;
                }
            }

            return new Count() { PhotosCount = photos };
        }
    }
}
