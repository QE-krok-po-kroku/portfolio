using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ProjectSimulator.Models;
using ProjectSimulator.Dao;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/portfolio/photos")]
    public class PhotosController : ApiController
    {
        readonly PhotoDao _dao = new PhotoDao();

        [Route("")]
        [HttpGet]
        public IEnumerable<Photo> GetPhotos()
        {
            //TODO: Sprint 2
            return new List<Photo>();
        }

        //TODO: Sprint 1
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Photo[] postPhotos)
        {

            foreach (Photo photo in postPhotos)
            {

                bool photoOk = false;
                IEnumerable<Photo> photoCollection = _dao.GetPhotos();
                foreach (Photo colectPhoto in photoCollection)
                {
                    //Test id
                    if (!colectPhoto.Id.Equals(photo.Id))
                    {
                        photoOk = true;
                    }

                    //Test grade field
                    if (
                        colectPhoto.Grade.ToLower().Equals("new") ||
                        colectPhoto.Grade.ToLower().Equals("good") ||
                        colectPhoto.Grade.ToLower().Equals("bad") ||
                        colectPhoto.Grade.ToLower().Equals("very_bad")
                        )
                    {
                        photoOk = true;
                    }

                    //Test very bad
                    if (
                        colectPhoto.Grade.ToLower().Equals("very_bad")
                        )
                    {
                        photoOk = false;
                    }

                }

                if (photoOk == true)
                {
                    _dao.AddPhoto(photo);
                }
            }

            int photos = _dao.GetPhotos().Count();
            return Request.CreateResponse(HttpStatusCode.Created, new Count() { PhotosCount = photos });
        }
    }
}
