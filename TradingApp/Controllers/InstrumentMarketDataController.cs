using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TradingApp.Models.InstrumentsMarketData;
using TradingApp.Services;
using TradingApp.Services.Instruments;

namespace TradingApp.Controllers
{
    public class InstrumentMarketDataController : Controller
    {
        private readonly InstrumentsMarketDataService _instrumentMarketDataService;

        public InstrumentMarketDataController(InstrumentsMarketDataService InstrumentMarketDataService)
        {
            _instrumentMarketDataService = InstrumentMarketDataService;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var tradableInstrumentsDataList = await _instrumentMarketDataService.GetListOfAllLastPricesAsync();
        //    var TradableInstrumentsList = new TradableInstrumentsDataList()
        //    {
        //        TradableInstrumentsList = tradableInstrumentsDataList
        //    };

        //    return View(tradableInstrumentsDataList);
        //}
        [HttpGet]
        public IActionResult Add()
        {
            var model = new InstrumentMarketDataViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstrumentMarketDataViewModel newInstrumentData)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            var successful = await _instrumentMarketDataService
            .AddInstrumentDataAsync(newInstrumentData);

            if (!successful)
            {
                return BadRequest("Could not add data.");
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


        //    var successful = await _instrumentMarketDataService
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


        //    var successful = await _instrumentMarketDataService
        //    .AddServiceAsync(newInstrument);

        //    if (!successful)
        //    {
        //        return BadRequest("Could not add instrument.");
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}