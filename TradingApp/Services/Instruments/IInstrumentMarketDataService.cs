using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;

namespace TradingApp.Services.Instruments
{
    public interface IInstrumentMarketDataService
    {
        Task<bool> AddInstrumentDataAsync(InstrumentMarketDataViewModel newInstrumentData);
        Task<bool> DeleteMarketDataAsync(Guid id);
        //Task<bool> UpdateServiceAsync(Guid id, InstrumentMarketData changedInstrumentData)
        Task<InstrumentMarketDataService[]> GetListOfAllInstrumentsDataAsync();
        Task<List<TradableInstrumentInfo>> GetListOfAllLastPricesAsync();
        Task<List<Instrument>> GetListOfAllTradableInstrumentsAsync();
    }
}
