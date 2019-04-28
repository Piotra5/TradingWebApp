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
        [Required(ErrorMessage ="Name is required")]
        public String Name { get; set; }

        [Display(Name = "Name")]
        [StringLength(15, MinimumLength=2)]
        [RegularExpression(@"[A-Z]+[a-zA-Z]+[0-9]*")]
        [Required(ErrorMessage = "Name is required")]
        public String Description { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Expiration Date is required")]
        public DateTimeOffset ExpirationDate { get; set; }

        [Display(Name = "Start of trading date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Trading start Date is required")]
        public DateTimeOffset AvailableFrom { get; set; }
    }
}
