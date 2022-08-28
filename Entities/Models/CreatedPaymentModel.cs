using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CreatedPaymentModel
    {
        public string PaymentId { get; set; }

        public string PaypalRedirectUrl { get; set; }
    }
}
