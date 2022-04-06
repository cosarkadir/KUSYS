using KUSYS.Web.UI.ProxyManagement;
using KUSYS.Web.UI.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IProxyHelper _proxyHelper;
        public StudentController(IProxyHelper proxyHelper)
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
            ServiceResponse<List<Student>> students = _proxyHelper.ExecuteCall<List<Student>, object>(ProxyServiceUrl.GET_STUDENT_LIST, null, RequestMethod.GET);
            return Json(students);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            string url = string.Format("{0}?id={1}", ProxyServiceUrl.DELETE_STUDENT, id);
            ServiceResponse<bool> students = _proxyHelper.ExecuteCall<bool, object>(url, null, RequestMethod.POST);
            return Json(students);
        }

        [HttpPost]
        public JsonResult Create([FromBody] Student student)
        {
            ServiceResponse<bool> students = _proxyHelper.ExecuteCall<bool, Student>(ProxyServiceUrl.CREATE_STUDENT, student, RequestMethod.POST);
            return Json(students);
        }
    }
}
