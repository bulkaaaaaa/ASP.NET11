using Microsoft.AspNetCore.Mvc;
using LR11.Filters;

namespace WebApplicationn11.Controllers
{
    public class HomeController : Controller
    {
        [ServiceFilter(typeof(LoggingActionFilter))]
        [ServiceFilter(typeof(UniqueUserFilter))]
        public ActionResult Index()
        {
            return View();
        }

        [ServiceFilter(typeof(LoggingActionFilter))]
        [ServiceFilter(typeof(UniqueUserFilter))]
        public ActionResult About()
        {
            return View();
        }
    }
}
