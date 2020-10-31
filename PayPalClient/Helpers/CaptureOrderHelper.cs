using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Payments;
using PayPalHttp;

namespace PayPalClient.Helpers
{
    public class CaptureOrderHelper
    {
        public async static Task<HttpResponse> CaptureOrder(string AuthorizationId)
        {
            var request = new AuthorizationsCaptureRequest(AuthorizationId);
            request.Prefer("return=representation");
            request.RequestBody(new CaptureRequest());
            var response = await PayPalClient.client().Execute(request);
            return response;
        }
    }
}
