using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ProjectSimulator.Models;
using ProjectSimulator.Dao;
using ProjectSimulator.Utils;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/portfolio/photos")]
    public class PhotosController : ApiController
    {
        readonly PhotoDao _dao = new PhotoDao();

        /**
         * Zwraca pusta liste zdjec
         **/
        [Route("")]
        [HttpGet]
        public IEnumerable<Photo> GetPhotos()
        {
            List<Photo> photos = new List<Photo>();
            //TODO: Sprint 2
            //return new List<Photo>();
            foreach(var photo in _dao.GetPhotos())
            {
                if (photo.Grade != "BAD" && photo.Grade != "VERY_BAD") photos.Add(photo);
            }
            return photos;
        }

        /*
         * Dodaje zdjecia do DB, zwraca 400 jezeli nie dodano zadnego zdjecia
         * 200 - jezeli dodano chociaz jedno
         * Dane Grade sa zaminiana na duze litery
         */
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Photo[] postPhotos)
        {

            int photoOkCount = 0;

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
                    photo.Grade.ToLower().Equals("very_bad") || photo.Grade.ToLower().Equals("bad")
                    )
                {
                    photoOk = false;
                }

                if (photoOk == true)
                {
                    //System.Console.WriteLine("PhotoOK: " + photoOk + " Id: " + photo.Id);
                    photo.Grade = photo.Grade.ToUpper();
                    _dao.AddPhoto(photo);
                    photoOkCount++;
                }
            }

            IEnumerable<Photo> countCollection = _dao.GetPhotos();
            int badCount = 0;
            int photos = countCollection.Count();
            foreach (Photo colectPhoto in countCollection)
            {
                if (colectPhoto.Grade.ToLower().Equals("very_bad") || colectPhoto.Grade.ToLower().Equals("bad"))
                {
                    badCount++;
                }
            }

            photos = photos - badCount;
            if (photoOkCount == 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "HTTP POST 400");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new Count() { PhotosCount = photos });
            }
        }
    }
}
