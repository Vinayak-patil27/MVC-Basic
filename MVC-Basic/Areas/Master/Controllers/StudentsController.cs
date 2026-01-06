using Microsoft.AspNetCore.Mvc;

namespace MVC_Basic.Areas.Master.Controllers
{
    [Area("Master")]
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
