﻿// This class was generated on Tue, 21 May 2019 11:25:19 PDT by version 0.1.0-dev+8fcb5f of Braintree SDK Generator
// OrderRequest.cs
// @version 0.1.0-dev+8fcb5f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPalCheckoutSdk.Orders
{
    /// <summary>
    /// The order request details.
    /// </summary>
    [DataContract]
    public class OrderRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public OrderRequest() {}

        /// <summary>
        /// Customizes the payer experience during the approval process for the payment with PayPal.<blockquote><strong>Note:</strong> Partners and Marketplaces might configure <code>brand_name</code> and <code>shipping_preference</code> during partner account setup, which overrides the request values.</blockquote>
        /// </summary>
        [DataMember(Name="application_context", EmitDefaultValue = false)]
        public ApplicationContext ApplicationContext;

        /// <summary>
        /// The intent to either capture payment immediately or authorize a payment for an order after order creation.
        /// </summary>
        [DataMember(Name="intent", EmitDefaultValue = false)]
        public string CheckoutPaymentIntent;

        /// <summary>
        /// The customer who approves and pays for the order. The customer is also known as the payer.
        /// </summary>
        [DataMember(Name="payer", EmitDefaultValue = false)]
        public Payer Payer;

        /// <summary>
        /// The instruction to process an order.
        /// </summary>
        [DataMember(Name="processing_instruction", EmitDefaultValue = false)]
        public string ProcessingInstruction;

        /// <summary>
        /// REQUIRED
        /// An array of purchase units. At present only 1 purchase_unit is supported. Each purchase unit establishes a contract between a payer and the payee. Each purchase unit represents either a full or partial order that the payer intends to purchase from the payee.
        /// </summary>
        [DataMember(Name="purchase_units", EmitDefaultValue = false)]
        public List<PurchaseUnitRequest> PurchaseUnits;

     
    }
}

