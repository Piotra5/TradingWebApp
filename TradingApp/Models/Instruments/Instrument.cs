using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingApp.Models.Instruments
{
    public class Instrument
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
        public DateTimeOffset AvailableFrom { get; set; }
    }
}
