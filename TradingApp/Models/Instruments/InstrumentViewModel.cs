using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace TradingApp.Models.Instruments
{
    public class InstrumentViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public String Name { get; set; }

        [Display(Name = "Name")]
        [StringLength(15, MinimumLength=2)]
        [RegularExpression(@"[A-Z]+[a-zA-Z]+[0-9]*")]
        [Required]
        public String Description { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset ExpirationDate { get; set; }

        [Display(Name = "AvailableFrom")]
        [DataType(DataType.DateTime)]
        public DateTimeOffset AvailableFrom { get; set; }
    }
}
