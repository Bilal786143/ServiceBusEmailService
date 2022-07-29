using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusEmailService.ViewModel
{
    public class OrderCreateRequest
    {
        [Required(ErrorMessage = "Email Address Is Required"), Display(Name = "Email Address")]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]

        public string Email { get; set; }


        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Phone Number Is Required"), Display(Name = "Phone #")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Address Is Required"), Display(Name = "Address")]
        public string Address { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime OrderDate { get; set; }

        public int ProductQuantity { get; set; }

        public decimal ProductPrice { get; set; }

        public string OrderType { get; set; }

        public Guid UserFid { get; set; }

        public int ProductFId { get; set; }
    }
}
