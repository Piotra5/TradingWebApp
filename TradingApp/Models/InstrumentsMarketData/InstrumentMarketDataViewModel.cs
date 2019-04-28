using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;

namespace TradingApp.Models.InstrumentsMarketData
{
    public class InstrumentMarketDataViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Instrument")]
        [Required(ErrorMessage = "Instrument Id is required")]
        public string InstrumentId { get; set; }

        [Display(Name = "Ask Price")]
        [Required(ErrorMessage = "Ask Price is required")]
        public float AskPrice { get; set; }

        [Display(Name = "Bid Price")]
        [Required(ErrorMessage = "Bid Price is required")]
        public float BidPrice { get; set; }

        public virtual Instrument Instrument { get; set; }
    }
}
