using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Data;
using TradingApp.Models.InstrumentsMarketData;
using TradingApp.Models.Trades;

namespace TradingApp.Services
{
    public class TradeService
    {
        private readonly ApplicationDbContext _context;

        #region InstrumentsMaketDataService()
        public TradeService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region MakeTrade()
        public async Task<bool> MakeTrade(MakeTradeViewModel newTrade)
        {

            var trade = new Trade
            {
                Id = Guid.NewGuid(),
                InstrumentId = newTrade.InstrumentId,
                IdentityUserId = newTrade.IdentityUserId,
                OpeningPrice = newTrade.OpeningPrice,
                Size = newTrade.Size,
                IsOpen = newTrade.IsOpen
            };

            _context.Trades.Add(trade);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region CloseTrade()
        public async Task<bool> CloseTradeAsync(Guid id)
        {
            var closed = false;
            var tradeToClose = await _context.Trades
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (tradeToClose != null)
            {
                tradeToClose.IsOpen = false;
                _context.Update(tradeToClose);
                closed = true;
            }
            else
            {
                closed = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && closed == true;

        }
        #endregion

        //#region EditService()
        //public async Task<bool> UpdateServiceAsync(Guid id, InstrumentMarketData changedInstrumentData)
        //{
        //    var instrument = await _context.Instruments
        //        .Where(x => x.Id == id)
        //        .SingleOrDefaultAsync();

        //    if (instrument != null)
        //    {
        //        instrument.Name = changedInstrumentData.Name;
        //        instrument.AvailableFrom = changedInstrumentData.AvailableFrom;
        //        instrument.Description = changedInstrumentData.Description;
        //        instrument.ExpirationDate = changedInstrumentData.ExpirationDate;
        //        _context.Update(instrument);

        //    }

        //    var saveResult = await _context.SaveChangesAsync();
        //    return saveResult == 1;
        //}
        //#endregion

        #region GetListOfAllData()
        public async Task<List<Trade>> GetListOfAllTradesAsync()
        {
            var tradesList = await _context.Trades
                .ToListAsync();
            return tradesList;
        }
        #endregion

        #region GetListOfAllData()
        public async Task<List<Trade>> GetListOfAllTradesForUserAsync(string UserId)
        {
            var tradesList = await _context.Trades
                .Where(t => t.IdentityUserId == UserId)
                .ToListAsync();

            return tradesList;
        }
        #endregion

        #region GetListOfAllData()
        public async Task<List<Trade>> GetListOfAllOpenTradesForUserAsync(string UserId)
        {
            var tradesList = await _context.Trades
                .Where(t => t.IdentityUserId == UserId && t.IsOpen == true)
                .ToListAsync();

            return tradesList;
        }
        #endregion

        #region GetListOfAllData()
        public async Task<List<Trade>> GetListOfAllClosedTradesForUserAsync(string UserId)
        {
            var tradesList = await _context.Trades
                .Where(t => t.IdentityUserId == UserId && t.IsOpen != true)
                .ToListAsync();

            return tradesList;
        }
        #endregion

    }
}
