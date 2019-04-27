using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;

namespace TradingApp.Models.Trades
{
    public class Trade
    {
        public Guid Id { get; set; }
        public string InstrumenId { get; set; }
        public string InstrumentMarketDataId { get; set; }
        public string UserId { get; set; }
        public float OpeningPrice { get; set; }
        public float Size { get; set; }

        public virtual Instrument Instrument { get; set; }
        public virtual InstrumentMarketData InstrumentMarketData { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
