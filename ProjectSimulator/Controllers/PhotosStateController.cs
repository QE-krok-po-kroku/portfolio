using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;
using ProjectSimulator.Utils;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/portfolio/photos_state")]
    public class PhotosStateController : ApiController
    {
        readonly PhotoDao _dao = new PhotoDao();

        [Route("")]
        [HttpGet]
        public IEnumerable<PhotoDto> GetPhotosState()
        {
            List<Photo> list = new List<Photo>();

            foreach (Photo colectPhoto in _dao.GetPhotos())
            {
                if (!colectPhoto.Grade.ToLower().Equals("very_bad") && !colectPhoto.Grade.ToLower().Equals("bad"))
                {
                    list.Add(colectPhoto);
                }
            }

            return PhotoToPhotoDto.Convert(list);
        }
    }
}
