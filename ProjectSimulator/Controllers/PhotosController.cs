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
//        [Route("")]
//        [HttpPost]
//        public HttpResponseMessage Post([FromBody] /* type variable */)
//        {
//            return Request.CreateResponse(HttpStatusCode.Created, new Count() { PhotosCount = 0});
//        }
    }
}
