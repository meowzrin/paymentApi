using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace paymentApi
{
    public class response
    {
        private List<string> _message;

        [JsonPropertyName("result")]
        public List<string> Result { get; set; }

        [JsonPropertyName("messages")]
        public List<string> Messages
        {
            get
            {
                if (this._message == null)
                    this._message = new List<string>();
                return this._message;
            }
            set
            {
                this._message = value;
            }
        }

    }
}
