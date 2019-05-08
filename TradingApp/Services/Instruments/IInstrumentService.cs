using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;

namespace TradingApp.Services.Instruments
{
    public interface IInstrumentService
    {
        Task<bool> AddInstrumentAsync(InstrumentViewModel newInstrument);
        Task<bool> DeleteInstrumentAsync(Guid id);
        Task<bool> UpdateInstrumentAsync(Guid id, Instrument changedInstrument);
        Task<List<Instrument>> GetListOfAllInstrumentsAsync();
    }
}
