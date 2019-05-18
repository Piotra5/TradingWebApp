using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;
using TradingApp.Services.Instruments;

namespace TradingApp.Controllers
{
    public class InstrumentController : Controller
    {
        private readonly IInstrumentService _instrumentService;
        private readonly UserManager<IdentityUser> _userManager;

        public InstrumentController(IInstrumentService instrumentService, UserManager<IdentityUser> userManager)
        {
            _instrumentService = instrumentService;
            _userManager = userManager;
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
        public IActionResult Add()
        {
            var model = new InstrumentViewModel();
            model.FromName = "Bitcoin";
            model.ToName = "US Dollar";
            model.FromCode = "BTC";
            model.ToCode = "USD";
            model.AvailableFrom = DateTimeOffset.UtcNow;
            model.ExpirationDate = DateTimeOffset.UtcNow.AddDays(186);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(InstrumentViewModel newInstrument)
        {
            newInstrument.Id = new Guid();
            newInstrument.AddedBy = _userManager.GetUserAsync(User).Id.ToString();
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