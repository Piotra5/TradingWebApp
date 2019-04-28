using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using TradingApp.Models.Instruments;

namespace TradingApp.Models.Trades
{
    public class TradeViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Instrument Id")]
        [Required(ErrorMessage = "Ask Price is required")]
        public string InstrumentMarketDataId { get; set; }

        [Display(Name = "User Id")]
        [Required(ErrorMessage = "User Id is required")]
        public string IdentityUserId { get; set; }

        [Display(Name = "User Id")]
        [Required(ErrorMessage = "User Id is required")]
        public float OpeningPrice { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "Size is required")]
        public float Size { get; set; }

        [Display(Name = "Is Open?")]
        public bool IsOpen { get; set; }

        [Display(Name = "CLosing Price")]
        public float? ClosingPrice { get; set; }

        [Display(Name = "StopLoss")]
        public float? StopLoss { get; set; }

        [Display(Name = "Target Price")]
        public float? TargetPrice { get; set; }

        [Display(Name = "Laverage")]
        public int Laverage { get; set; }

    }
}
