using System;
using System.Collections.Generic;
using System.Text;

namespace PayPalClient
{
    public class PayPalConfig
    {
        public string CancelUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string ClientID { get; set; }
        public string ClientSecretID { get; set; }
        public bool IsSandBox { get; set; }
    }
}
