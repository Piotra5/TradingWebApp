using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TradingApp.Data;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;

namespace TradingApp.Services.Instruments
{
    public class InstrumentService : IInstrumentService
    {
        private readonly ApplicationDbContext _context;

        #region InstrumentService()

        public InstrumentService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddInstrumentAsync()
        public async Task<bool> AddInstrumentAsync(InstrumentViewModel newInstrument)
        {

            var instrument = new Instrument
            {
                Id = Guid.NewGuid(),
                FromName = newInstrument.FromName,
                FromCode = newInstrument.FromCode,
                ToName = newInstrument.ToName,
                ToCode = newInstrument.ToCode,
                AvailableFrom = newInstrument.AvailableFrom,
                Description = newInstrument.Description,
                ExpirationDate = newInstrument.ExpirationDate
            };

            _context.Instruments.Add(instrument);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteInstrumentAsync()
        public async Task<bool> DeleteInstrumentAsync(Guid id)
        {
            var deleted = false;
            var instrument = await _context.Instruments
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (instrument != null)
            {
                _context.Remove(instrument);
                deleted = true;
            }
            else
            {
                deleted = false;
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1 && deleted == true;

        }
        #endregion

        #region UpdateInstrument()
        public async Task<bool> UpdateInstrumentAsync(Guid id, Instrument changedInstrument)
        {
            var instrument = await _context.Instruments
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (instrument != null)
            {
                instrument.Id = Guid.NewGuid();
                instrument.FromName = changedInstrument.FromName;
                instrument.FromCode = changedInstrument.FromCode;
                instrument.ToName = changedInstrument.ToName;
                instrument.ToCode = changedInstrument.ToCode;
                instrument.AvailableFrom = changedInstrument.AvailableFrom;
                instrument.Description = changedInstrument.Description;
                instrument.ExpirationDate = changedInstrument.ExpirationDate;
                _context.Update(instrument);

            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region GetListOfAllInstruments()
        public async Task<List<Instrument>> GetListOfAllInstrumentsAsync()
        {
            var services = await _context.Instruments
                .ToListAsync();
            return services;
        }
        #endregion
    }
}