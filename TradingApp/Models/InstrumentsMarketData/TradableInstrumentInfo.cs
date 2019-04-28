using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingApp.Models.InstrumentsMarketData
{
    public class TradableInstrumentInfo
    {
        public string Name { get; set; }
        public string InstrumentId { get; set; }
        public DateTimeOffset AvailableFrom { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public float BidPrice { get; set; }
        public float AskPrice { get; set; }

    }
}
