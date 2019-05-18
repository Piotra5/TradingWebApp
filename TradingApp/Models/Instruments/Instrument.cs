using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingApp.Models.Instruments
{
    public class Instrument
    {
        public Guid Id { get; set; }
        public String FromName { get; set; }
        public String FromCode { get; set; }
        public String ToName { get; set; }
        public String ToCode { get; set; }
        public DateTimeOffset AvailableFrom { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public String Description { get; set; }
        public String AddedBy { get; set; }
        public String EditedBy { get; set; }
    }
}
