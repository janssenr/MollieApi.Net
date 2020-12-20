<h1 align="center">Mollie API client for ASP.NET</h1>

Accepting [iDEAL](https://www.mollie.com/payments/ideal/), [Apple Pay](https://www.mollie.com/payments/apple-pay), [Bancontact](https://www.mollie.com/payments/bancontact/), [SOFORT Banking](https://www.mollie.com/payments/sofort/), [Creditcard](https://www.mollie.com/payments/credit-card/), [SEPA Bank transfer](https://www.mollie.com/payments/bank-transfer/), [SEPA Direct debit](https://www.mollie.com/payments/direct-debit/), [PayPal](https://www.mollie.com/payments/paypal/), [Belfius Direct Net](https://www.mollie.com/payments/belfius/), [KBC/CBC](https://www.mollie.com/payments/kbc-cbc/), [paysafecard](https://www.mollie.com/payments/paysafecard/), [ING Home'Pay](https://www.mollie.com/payments/ing-homepay/), [Giftcards](https://www.mollie.com/payments/gift-cards/), [Giropay](https://www.mollie.com/payments/giropay/), [EPS](https://www.mollie.com/payments/eps/) and [Przelewy24](https://www.mollie.com/payments/przelewy24/) online payments without fixed monthly costs or any punishing registration procedures. Just use the Mollie API to receive payments directly on your website or easily refund transactions to your customers.

[![Nuget](https://img.shields.io/nuget/v/MollieApi)](https://www.nuget.org/packages/MollieApi/)
[![Nuget](https://img.shields.io/nuget/dt/MollieApi)](https://www.nuget.org/packages/MollieApi/)

## Requirements ##
To use the Mollie API client, the following things are required:

+ Get yourself a free [Mollie account](https://www.mollie.com/signup). No sign up costs.
+ Now you're ready to use the Mollie API client in test mode.
+ Follow [a few steps](https://www.mollie.com/dashboard/?modal=onboarding) to enable payment methods in live mode, and let us handle the rest.

## Nuget Installation ##

By far the easiest way to install the Mollie API client is to use the [Nuget Package](https://www.nuget.org/packages/MollieApi/).
```
Install-Package MollieApi
```
The version of the API client corresponds to the version of the API it implements.

## How to receive payments ##

To successfully receive a payment, these steps should be implemented:

1. Use the Mollie API client to create a payment with the requested amount, currency, description and optionally, a payment method. It is important to specify a unique redirect URL where the customer is supposed to return to after the payment is completed.

2. Immediately after the payment is completed, the platform will send an asynchronous request to the configured webhook to allow the payment details to be retrieved, so you know when exactly to start processing the customer's order.

3. The customer returns, and should be satisfied to see that the order was paid and is now being processed.

Find the full documentation online on [docs.mollie.com](https://docs.mollie.com).

## Getting started ##

Initializing the Mollie API client, and setting your API key.

```c#
var mollie = new MollieApiClient();
mollie.SetApiKey("test_dHar4XY7LxsDOtmnkVtjNVWXLSlXsM");
``` 

Creating a new payment.

```c#
var payment = await mollie.Payments.Create(new Payment
{
	Amount = new Amount
	{
		Currency = "EUR",
		Value = "10.00"
	},
	Description = "My first API payment",
	RedirectUrl = new Uri("https://webshop.example.org/order/12345/"),
	WebhookUrl = new Uri("https://webshop.example.org/mollie-webhook/")
});
```
_After creation, the payment id is available in the `payment.Id` property. You should store this id with your order._

After storing the payment id you can send the customer to the checkout using the `payment.GetCheckoutUrl()`.  

```c#
Response.Redirect(payment.GetCheckoutUrl(), true);
```

## Retrieving payments ##
We can use the `payment.Id` to retrieve a payment and check if the payment `IsPaid`.

```c#
var payment = await mollie.Payments.Get(payment.Id);
if (payment.IsPaid())
{
	Console.WriteLine("Payment received.");
}
```

Or retrieve a collection of payments.

```c#
var payments = mollie.Payments.Page(); 
```

## Payment webhook ##

When the status of a payment changes the `WebhookUrl` we specified in the creation of the payment will be called.  
There we can use the `id` from the POST parameters to check te status and act upon that.


## Multicurrency ##
Since 2.0 it is now possible to create non-EUR payments for your customers.
A full list of available currencies can be found [in the documentation](https://docs.mollie.com/guides/multicurrency).

```c#
var payment = await mollie.Payments.Create(new Payment
{
	Amount = new Amount
	{
		Currency = "USD",
		Value = "10.00"
	},
	Description = "Order #12345",
	RedirectUrl = new Uri("https://webshop.example.org/order/12345/"),
	WebhookUrl = new Uri("https://webshop.example.org/mollie-webhook/")
});
```
_After creation, the `SettlementAmount` will contain the EUR amount that will be settled on your account._


### Fully integrated iDEAL payments ###

If you want to fully integrate iDEAL payments in your web site, some additional steps are required. First, you need to
retrieve the list of issuers (banks) that support iDEAL and have your customer pick the issuer he/she wants to use for
the payment.

Retrieve the iDEAL method and include the issuers

```c#
var parameters = new Dictionary<string, string>
{
	{ "include", "issuers" }
};
var method = await mollie.Methods.Get(PaymentMethod.IDEAL, parameters);
```

_`method.Issuers` will be a list of objects. Use the property `Id` of this object in the API call, and the property `Name` for displaying the issuer to your customer._

Create a payment with the selected issuer:

```c#
var payment = await mollie.Payments.Create(new Payment
{
	Amount = new Amount
	{
		Currency = "EUR",
		Value = "10.00"
	},
	Description = "My first API payment",
	RedirectUrl = new Uri("https://webshop.example.org/order/12345/"),
	WebhookUrl = new Uri("https://webshop.example.org/mollie-webhook/"),
	Method = PaymentMethod.IDEAL,
	Issuer = "ideal_INGBNL2A"
});
```

_The `Links` property of the `payment` object will contain an object `Checkout` with a `Href` property, which is a URL that points directly to the online banking environment of the selected issuer.
A short way of retrieving this URL can be achieved by using the `payment.GetCheckoutUrl()`._

### Refunding payments ###

The API also supports refunding payments. Note that there is no confirmation and that all refunds are immediate and
definitive. Refunds are supported for all methods except for paysafecard and gift cards.

```c#
var payment = await mollie.Payments.Get(payment.Id);

// Refund € 2 of this payment
var refund = await mollie.PaymentRefunds.CreateFor(payment, new Refund
{
	Amount = new Amount
	{
		Currency = "EUR",
		Value = "2.00"
	}
});
```

## API documentation ##
If you wish to learn more about the API, please visit the [Mollie Developer Portal](https://www.mollie.com/developers). API Documentation is available in English.

## Want to help make the API client even better? ##

Want to help make the API client even better? Create a [pull request](https://github.com/janssenr/MollieApi.Net/pulls).

## License ##
[MIT (Massachusetts Institute of Technology) License](https://licenses.nuget.org/MIT).
Copyright (c) 2020, Rob Janssen
