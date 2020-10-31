using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PayPalCheckoutSdk.Payments;
using PayPalClient.Helpers;

namespace PayPalClient
{
    public class PayPalService : IPayPalService
    {
        private readonly PayPalConfig palConfig;
        public PayPalService(IOptions<PayPalConfig> options)
        {
            Helpers.PayPalClient.SetEnvironment(options.Value.ClientID, options.Value.ClientSecretID, options.Value.IsSandBox);
            palConfig = options.Value;

        }
        public async Task<PayPalCheckoutSdk.Orders.Order> AuthorizePaymentOrderAsync(string orderid)
        {
            return (await AuthorizeOrderHelper.AuthorizeOrder(orderid)).Result<PayPalCheckoutSdk.Orders.Order>();
        }

        public async Task<Capture> CapturePaymentAsync(string AuthorizationID)
        {
            return (await CaptureOrderHelper.CaptureOrder(AuthorizationID)).Result<Capture>();
        }
        public async Task<Refund> CaptureRefundAsync(string CaptureID, string Amount, string currencyCode = "USD")
        {
            return (await RefundHelper.CapturesRefund(CaptureID, Amount, currencyCode)).Result<Refund>();
        }
        public async Task<PayPalCheckoutSdk.Orders.Order> CreatePaymentOrderAsync(string Amount, string currencyCode = "USD", Dictionary<string, string> customParameters = null)
        {
            Uri uri =new Uri(palConfig.ReturnUrl);
            if (customParameters != null)
                uri = uri.ExtendQuery(customParameters);
            return (await CreateOrderHelper.CreateOrderWithMinimumFields(Amount, currencyCode, uri.AbsoluteUri, palConfig.CancelUrl)).Result<PayPalCheckoutSdk.Orders.Order>();
        }

        


    }
}
