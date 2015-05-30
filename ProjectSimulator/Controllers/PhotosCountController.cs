using System.Web.Http;
using ProjectSimulator.Dao;
using ProjectSimulator.Models;

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
            //TODO: Sprint 3
            return new Count() {PhotosCount = 0};
        }
    }
}
