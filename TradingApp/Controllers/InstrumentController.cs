using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;
using TradingApp.Services;

namespace TradingApp.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly InstrumentService _instrumentService;

        public InstrumentController(InstrumentService InstrumentService)
        {
            _instrumentService = InstrumentService;
        }

        public async Task<IActionResult> Index()
        {
            var instrumentsList = await _instrumentService.GetListOfAllInstrumentsAsync();

            var model = new InstrumentsListViewModel()
            {
                Instruments = instrumentsList
            };
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new InstrumentViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstrumentViewModel newInstrument)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            var successful = await _instrumentService
            .AddInstrumentAsync(newInstrument);

            if (!successful)
            {
                return BadRequest("Could not add instrument.");
            }

            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(InstrumentViewModel newInstrument)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }


        //    var successful = await _instrumentService
        //    .AddServiceAsync(newInstrument);

        //    if (!successful)
        //    {
        //        return BadRequest("Could not add instrument.");
        //    }

        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(InstrumentViewModel newInstrument)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return RedirectToAction("Index");
        //    }


        //    var successful = await _instrumentService
        //    .AddServiceAsync(newInstrument);

        //    if (!successful)
        //    {
        //        return BadRequest("Could not add instrument.");
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}