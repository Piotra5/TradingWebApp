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

        [Display(Name = "FROM Name")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(15, MinimumLength=2)]
        [RegularExpression(@"[a-zA-Z0-9\s]*")]
        public String FromName { get; set; }

        [Display(Name = "FROM Code")]
        [StringLength(7, MinimumLength=2)]
        [Required(ErrorMessage ="From Code is required")]
        [RegularExpression(@"[a-zA-Z0-9\s]*")]
        public String FromCode { get; set; }
        
        [Display(Name = "TO Name")]
        [StringLength(77, MinimumLength=2)]
        [RegularExpression(@"[a-zA-Z0-9\s]*")]
        public String ToCode { get; set; }

        [Display(Name = "TO Code")]
        [StringLength(15, MinimumLength=2)]
        [RegularExpression(@"[a-zA-Z0-9\s]*")]
        public String ToName { get; set; }

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
        public String AddedBy { get; set; }
        public String EditedBy { get; set; }
    }
}
