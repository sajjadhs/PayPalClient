# Paypal Client

Handy paypal client which can be used in .net core projects

This project is done over the [paypal's official sdk](https://github.com/paypal/Checkout-NET-SDK) and makes it easier and ready to use by one click.

Only thing you need is to register in paypal website and get you clientid and client secret id.

Call each function which is needed to get create payment, authorize payment, capture or refund it.

## Setup

Use nuget:
```bash
Install-Package SM.Net.PayPalClient -Version 1.0.1
```

Or, Only clone the repository and add a reference to the project in yours.

## Code Usage

If you are using appseting.json file the define these keys:

```c#
 {
"AllowedHosts": "*",
  "PayPalConfig": {
    "CancelUrl": "https://localhost:44315/payment/cancelled OR Your Public Address",
    "ReturnUrl": "https://localhost:44315/payment/verify OR Your Public Address",
    "ClientID": "You Will GET THIS From PayPAL Account",
    "ClientSecretID": "You Will GET THIS From PayPAL Account",
    "IsSandBox": true
  }
```

Note: If you are going to publish you app to realworld then make IsSandBox:false

Register the Paypalclient in your startup:

```c#
services.Configure<PayPalConfig>(options=>Configuration.GetSection("PayPalConfig").Bind(options));
services.AddSingleton<IPayPalService,PayPalService>();
```

And finally your payment controller can be like below:
```c#
public class PaymentController : Controller
    {
        private readonly IPayPalService payPalService;
        public PaymentController(IPayPalService payPalService)
        {
            this.payPalService = payPalService;
        }
        //create payment and redirect user to paypal
        public async Task<IActionResult> CreatePayment(string amount, string pid)
        {
            //pid is my parameter which i want to get it after the payment is done.
            var res = await payPalService.CreatePaymentOrderAsync(amount, customParameters: new Dictionary<string, string>() { { "pid", pid } });
            return Redirect(res.Links.FirstOrDefault(q => q.Rel.ToLower().Equals("approve")).Href);
        }
        public IActionResult cancelled()
        {
            return View();
        }
        //Return from paypal
        public async Task<IActionResult> Verify(string token = "", string PayerID = "", string pid = "")
        {
            var AuthorizedPayment = await payPalService.AuthorizePaymentOrderAsync(token);
            string AuthorizationID = AuthorizedPayment.PurchaseUnits[0].Payments.Authorizations[0].Id;
            var capture = await payPalService.CapturePaymentAsync(AuthorizationID);
       
            return View();
        }

        ///we can capture the payment and finalize it
        public async Task<JsonResult> Capture(string aid)
        {
            var FinalizePayment = await payPalService.CapturePaymentAsync(aid);
            string captureID = FinalizePayment.Id;
            return Json(captureID);
        }

        ///we can refund
        public async Task<IActionResult> Refund(string captureId, string amount, string unit)
        {
            var tt = await payPalService.CaptureRefundAsync(captureId, amount, unit);
            return Json(true);
        }
    }
```
## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.


## License
[MIT](https://choosealicense.com/licenses/mit/)
