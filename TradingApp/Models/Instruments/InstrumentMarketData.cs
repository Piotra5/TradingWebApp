using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingApp.Models.Instruments
{
    public class InstrumentMarketData
    {
        public Guid Id { get; set; }
        public string InstrumentId { get; set; }
        public DateTimeOffset? ExpirationTime { get; set; }
        public DateTimeOffset CreationTime { get; set; }

        public virtual Instrument Instrument { get; set; }
    }
}