using ProjectSimulator.Dao;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectSimulator.Controllers
{
    [RoutePrefix("api/utility")]
    public class UtilityController : ApiController
    {
        readonly PhotoDao _dao = new PhotoDao();

        [Route("reset")]
        [HttpPost]
        public HttpResponseMessage ResetApplication()
        {
            _dao.ResetDatabase();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}