using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flutterwave_API.Models
{
    public class ValidationClass
    {
        [Required(ErrorMessage = "The Amount Field Must be filled")]
        [DataType(DataType.Currency, ErrorMessage = "Enter a valid amount")]
        public string Amount { get; set; }

    }
}