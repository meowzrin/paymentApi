using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace paymentApi.domain
{
    public class PaymentResponse
    {
        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }
   
}
