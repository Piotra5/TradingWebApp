using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingApp.Models.Instruments;

namespace TradingApp.Controllers
{
    public class InstrumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new InstrumentViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstrumentViewModel instrument)
        {
            
            return RedirectToAction("Index");
        }
    }
}