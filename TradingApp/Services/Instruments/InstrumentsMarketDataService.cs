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
    public class InstrumentsMarketDataService : IInstrumentsMarketDataService
    {
        private readonly ApplicationDbContext _context;

        #region InstrumentsMaketDataService()

        public InstrumentsMarketDataService(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddInstrumentDataAsync()
        public async Task<bool> AddInstrumentDataAsync(InstrumentMarketDataViewModel newInstrumentData)
        {

            var instrumentData = new InstrumentMarketDataService
            {
                Id = Guid.NewGuid(),
                InstrumentId = newInstrumentData.InstrumentId,
                BidPrice = newInstrumentData.BidPrice,
                AskPrice = newInstrumentData.AskPrice
            };

            _context.InstrumentsMarketData.Add(instrumentData);

            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }
        #endregion

        #region DeleteMarketDataAsync()
        public async Task<bool> DeleteMarketDataAsync(Guid id)
        {
            var deleted = false;
            var instrumentData = await _context.InstrumentsMarketData
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (instrumentData != null)
            {
                _context.Remove(instrumentData);
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
        public async Task<InstrumentMarketDataService[]> GetListOfAllInstrumentsDataAsync()
        {
            var instrumentsData = await _context.InstrumentsMarketData
                .ToArrayAsync();
            return instrumentsData;
        }
        #endregion

        #region GetListOfLastPricesAsync()
        public async Task<List<TradableInstrumentInfo>> GetListOfAllLastPricesAsync()
        {
            var instrumentsData = await _context.InstrumentsMarketData
                .ToListAsync();

            var tradableInstruments = await GetListOfAllInstrumentsDataAsync();

            var instrumentsDataSorted = instrumentsData.OrderBy(o => o.Date).ToList();

            var TradableInstrumentsData = new List<TradableInstrumentInfo>();
            
            foreach(var cInstrument in tradableInstruments)
            {
                foreach (var iData in instrumentsDataSorted)
                {
                    if(cInstrument.InstrumentId == iData.InstrumentId)
                    {
                        var tradableInstrument = new TradableInstrumentInfo
                        {
                            Name = cInstrument.Instrument.Name,
                            ExpirationDate = cInstrument.Instrument.ExpirationDate,
                            AvailableFrom = cInstrument.Instrument.AvailableFrom,
                            AskPrice = iData.AskPrice,
                            BidPrice = iData.BidPrice

                        };
                        TradableInstrumentsData.Add(tradableInstrument);


                    }
                }
            }

            return TradableInstrumentsData;
        }
        #endregion

        #region GetInstrumentDataById

        #endregion

        #region GetCurrentTradableInstruments()
        public async Task<List<Instrument>> GetListOfAllTradableInstrumentsAsync()
        {
        var currentInstruments = await _context.Instruments
            .Where(o => o.AvailableFrom > DateTimeOffset.Now)
            .ToListAsync();

            return currentInstruments;
        }
        #endregion

    }
}