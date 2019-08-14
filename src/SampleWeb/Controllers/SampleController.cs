using Microsoft.AspNetCore.Mvc;
using SampleWeb.Services.Samples;
using SampleWeb.Services.Samples.Models;

namespace SampleWeb.Controllers
{
    public class SampleController : Controller
    {
        private readonly ISampleDataService _sampleDataService;

        public SampleController(ISampleDataService sampleDataService)
        {
            _sampleDataService = sampleDataService;
        }

        [HttpGet]
        public IActionResult TestForm()
        {
            return View(_sampleDataService.GetFormWithFileViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TestForm(FormWithFileViewModel data)
        {
            if (!ModelState.IsValid)
                return View(data);

            var success = _sampleDataService.ProcessFormWithFileViewModel(data);
            if (success)
                return RedirectToAction("Index", "Home");

            ModelState.AddModelError("", "Unknown error");
            return View(data);
        }
    }
}