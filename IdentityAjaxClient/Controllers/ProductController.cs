using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityAjaxClient.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public ActionResult Details(int id) { return View(); }
        public ActionResult Create() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection) { return View(); }
        public ActionResult Edit(int id) { return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection) { return View(); }
        public ActionResult Delete(int id) { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection) { return View(); }
        public IActionResult Index()
        {
            return View();
        }
    }
}
