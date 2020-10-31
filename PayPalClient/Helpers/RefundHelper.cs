using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Payments;
using PayPalHttp;

namespace PayPalClient.Helpers
{
    public class RefundHelper
    {
        public async static Task<HttpResponse> CapturesRefund(string CaptureId, string amount, string currecncode)
        {
            var request = new CapturesRefundRequest(CaptureId);
            request.Prefer("return=representation");
            RefundRequest refundRequest = new RefundRequest()
            {
                Amount = new Money
                {
                    Value = amount,
                    CurrencyCode = currecncode
                }
            };
            request.RequestBody(refundRequest);
            var response = await PayPalClient.client().Execute(request);
            return response;
        }
    }
}
