using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;
using TradingApp.Models.Trades;
using TradingApp.Services;
using TradingApp.Services.Instruments;
using TradingApp.Services.Trades;

namespace TradingApp.Controllers
{
    public class TradeController : Controller
    {
        private readonly ITradeService _tradeService;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IInstrumentService _instrumentService;

        private readonly InstrumentMarketDataService _instrumentDataService;

        #region TradeController()
        public TradeController(TradeService tradeService, UserManager<IdentityUser> userManager,
            InstrumentService instrumentService,InstrumentMarketDataService instrumentMarketDataService)
        {
            _tradeService = tradeService;
            _userManager = userManager;
            _instrumentService = instrumentService;
            _instrumentDataService = instrumentMarketDataService;

        }
        #endregion

        #region Index()
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userOpenTrades = await _tradeService.GetListOfAllOpenTradesForUserAsync(currentUser.Id);
            var OpenTrades = new TradesListViewModel()
            {
                TradesList = userOpenTrades
            };

            return View(OpenTrades);
        }
        #endregion

        //public async Task<IActionResult> Make(Instrument tradableInstrument)
        //{
        //    var currentUser = await _userManager.GetUserAsync(User);
        //    var model = new MakeTradeViewModel()
        //    {
        //        InstrumentId = tradableInstrument.InstrumentId,
        //        BidPrice = tradableInstrument.BidPrice,
        //        AskPrice = tradableInstrument.AskPrice,
        //        IdentityUserId = currentUser.Id,
        //        InstrumentName = tradableInstrument.Name,

        //    };

        //    return View(model);
        //}

        [HttpPost]
        public async Task<IActionResult> MakeTrade(MakeTradeViewModel trade)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }


            var successful = await _tradeService
            .MakeTrade(trade);

            if (!successful)
            {
                return BadRequest("Could not make a trade.");
            }

            return RedirectToAction("Index");
        }




    }
}