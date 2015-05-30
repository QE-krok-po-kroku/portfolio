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

                bool photoOk = true;
                IEnumerable<Photo> photoCollection = _dao.GetPhotos();

                foreach (Photo colectPhoto in photoCollection)
                {
                    //Test id
                    if (colectPhoto.Id.Equals(photo.Id))
                    {
                        photoOk = false;
                        break;
                    }
                }

                //Test grade field
                if (
                    (!photo.Grade.ToLower().Equals("new") &&
                    !photo.Grade.ToLower().Equals("good") &&
                    !photo.Grade.ToLower().Equals("bad") &&
                    !photo.Grade.ToLower().Equals("very_bad")
                    ) && photoOk == true
                    )
                {
                    photoOk = false;
                }

                //Test very bad
                if (
                    photo.Grade.ToLower().Equals("very_bad")
                    )
                {
                    photoOk = false;
                }

                if (photoOk == true)
                {
                    //System.Console.WriteLine("PhotoOK: " + photoOk + " Id: " + photo.Id);
                    photo.Grade = photo.Grade.ToUpper();
                    _dao.AddPhoto(photo);
                }
            }

            IEnumerable<Photo> countCollection = _dao.GetPhotos();
            int badCount = 0;
            int photos = countCollection.Count();
            foreach (Photo colectPhoto in countCollection)
            {
                if (colectPhoto.Grade.ToLower().Equals("very_bad"))
                {
                    badCount++;
                }
            }

            photos = photos - badCount;
            return Request.CreateResponse(HttpStatusCode.Created, new Count() { PhotosCount = photos });
        }
    }
}
