using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Models.Trades;

namespace TradingApp.Services.Trades
{
    public interface ITradeService
    {
        Task<bool> MakeTrade(MakeTradeViewModel newTrade);
        Task<bool> CloseTradeAsync(Guid id);
        //Task<bool> UpdateServiceAsync(Guid id, InstrumentMarketData changedInstrumentData)
        Task<List<Trade>> GetListOfAllTradesAsync();
        Task<List<Trade>> GetListOfAllTradesForUserAsync(string UserId);
        Task<List<Trade>> GetListOfAllOpenTradesForUserAsync(string UserId);
        Task<List<Trade>> GetListOfAllClosedTradesForUserAsync(string UserId);
    }
}
