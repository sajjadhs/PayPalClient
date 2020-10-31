using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Payments;
using PayPalHttp;

namespace PayPalClient
{
    public interface IPayPalService
    {
        /// <summary>
        /// to create payment request - step 1
        /// <b>UseFul info:</b> status,orderid,intent,links,amount,currency code
        /// </summary>
        /// <param name="Amount"></param>
        /// <param name="currencyCode"></param>
        /// <returns>This will return some links in reposone. use approve/or each one of the links to redirect user to payment according to your interface</returns>
        Task<PayPalCheckoutSdk.Orders.Order> CreatePaymentOrderAsync(string Amount, string currencyCode = "USD", Dictionary<string, string> customParameters = null);


        /// <summary>
        /// to Confirm Payment - step 2 
        /// <b>UseFul info:</b> status,order-id,intent,links,amount,currency code,<b>AuthorizationID(is inside the payments)</b>, Buyer EmailAddress and Buyer Other Info
        /// </summary>
        /// <param name="orderid"></param>
        /// <returns></returns>
        Task<PayPalCheckoutSdk.Orders.Order> AuthorizePaymentOrderAsync(string orderid);


        /// <summary>
        /// to Finalize payment - step 3
        /// <b>UseFul info:</b> status,capture-id,links
        /// </summary>
        /// <param name="AuthorizationID">You can get this is id from AuthurizePaymentAsync-Respone.Purchaseunits[0].Payments.Authirizations[0].Id.</param>
        /// <returns></returns>
        Task<Capture> CapturePaymentAsync(string AuthorizationID);


        /// <summary>
        /// to Refund - this step after payment capturing can be used
        /// <b>UseFul info:</b> status,refund-id,links
        /// </summary>
        /// <param name="CaptureID"></param>
        /// <param name="Amount"></param>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        Task<Refund> CaptureRefundAsync(string CaptureID, string Amount, string currencyCode = "USD");
    }
}
