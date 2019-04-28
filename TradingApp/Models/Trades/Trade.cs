using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;
using TradingApp.Models.InstrumentsMarketData;

namespace TradingApp.Models.Trades
{
    public class Trade
    {
        public Guid Id { get; set; }
        //public string InstrumentId { get; set; }
        public string InstrumentId { get; set; }
        public string IdentityUserId { get; set; }
        public float OpeningPrice { get; set; }
        public float Size { get; set; }
        public bool IsOpen { get; set; }
        public float? ClosingPrice { get; set; }
        public float? StopLoss { get; set; }
        public float? TargetPrice { get; set; }
        public int Laverage { get; set; }
        public bool Long { get; set; }


        //public virtual Instrument Instrument { get; set; }
        public virtual Instrument InstrumentM{ get; set; }
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
