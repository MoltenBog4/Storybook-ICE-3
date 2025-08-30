using Microsoft.AspNetCore.Mvc;
using Storybook.Mvc.Services;

namespace Storybook.Mvc.Controllers
{
    public class StoryController : Controller
    {
        private readonly IScriptService _svc;
        public StoryController(IScriptService svc) => _svc = svc;

        public IActionResult Index()
        {
            var items = _svc.GetSortedScript();
            return View(items);
        }

        public IActionResult Line(int index = 0)
        {
            var count = _svc.Count;
            if (count == 0) return RedirectToAction(nameof(Index));
            if (index < 0) index = 0;
            if (index >= count) index = count - 1;

            var node = _svc.GetLine(index);
            ViewBag.Index = index;
            ViewBag.Count = count;
            return View(node);
        }
    }
}
