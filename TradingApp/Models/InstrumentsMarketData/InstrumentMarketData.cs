using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;

namespace TradingApp.Models.InstrumentsMarketData
{
    public class InstrumentMarketDataService
    {
        public Guid Id { get; set; }
        public string InstrumentId { get; set; }
        public DateTimeOffset Date { get; set; }
        public float AskPrice { get; set; }
        public float BidPrice { get; set; }

        public virtual Instrument Instrument { get; set; }
    }
}