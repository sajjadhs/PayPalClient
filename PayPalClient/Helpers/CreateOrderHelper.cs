using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;

namespace PayPalClient.Helpers
{
    public class CreateOrderHelper
    {
        private static OrderRequest BuildRequestBodyWithMinimumFields(string amount,
            string currencyCode,string returnUrl,string cancelurl)
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "AUTHORIZE",
                ApplicationContext = new ApplicationContext
                {
                    CancelUrl = cancelurl,
                    ReturnUrl = returnUrl
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest{
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = currencyCode,
                            Value = amount
                        }

                    }
                },
                
            };

            return orderRequest;
        }

        public async static Task<HttpResponse> CreateOrderWithMinimumFields(string amount, string currencyCode, string returnUrl, string cancelUrl)
        {
            var request = new OrdersCreateRequest();
            request.Headers.Add("prefer", "return=representation");
            request.RequestBody(BuildRequestBodyWithMinimumFields(amount, currencyCode,returnUrl,cancelUrl));
            var response = await PayPalClient.client().Execute(request);
            return response;
        }
    }
}
