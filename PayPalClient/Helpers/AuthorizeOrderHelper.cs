using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;

namespace PayPalClient.Helpers
{
    public class AuthorizeOrderHelper
    {
        public async static Task<HttpResponse> AuthorizeOrder(string OrderId)
        {
            var request = new OrdersAuthorizeRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new AuthorizeRequest());
            var response = await PayPalClient.client().Execute(request);

            return response;
        }
    }
}
