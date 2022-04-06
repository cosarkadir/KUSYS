using KUSYS.Web.UI.ProxyManagement;
using KUSYS.Web.UI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly IProxyHelper _proxyHelper;
        public CourseController(IProxyHelper proxyHelper)
        {
            _proxyHelper = proxyHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            ServiceResponse<List<Course>> students = _proxyHelper.ExecuteCall<List<Course>, object>(ProxyServiceUrl.GET_COURSE_LIST, null, RequestMethod.GET);
            return Json(students);
        }
    }
}