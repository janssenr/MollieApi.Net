using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class OrderPaymentEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateOrderPayment()
        {
            var requestContent = new Payment
            {
                Method = "banktransfer"
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_stTC2WHAuS/payments"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var responseContent = new Payment
            {
                Resource = "payment",
                Id = "tr_WDqYK6vllg",
                Mode = "test",
                Amount = new Amount
                {
                    Currency = "EUR",
                    Value = "698.00"
                },
                Status = "open",
                Description = "Order #1337 (Lego cars)",
                CreatedAt = new DateTime(2018,12,1,17,9,2),
                Method = "banktransfer",
                Metadata = null,
                OrderId = "ord_stTC2WHAuS",
                IsCancelable = true,
                Locale = new CultureInfo("nl_NL"),
                ProfileId = "pfl_URR55HPMGx",
                SequenceType = "oneoff",
                SettlementAmount = new Amount
                {
                    Value = "698.00",
                    Currency = "EUR"
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_WDqYK6vllg"),
                        Type = "application/hal+json"
                    },
                    Order = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/orders/ord_stTC2WHAuS"),
                        Type = "application/hal+json"
                    },
                    Checkout = new Url
                    {
                        Href = new Uri("https://www.mollie.com/paymentscreen/testmode/?method=banktransfer&token=fgnwdh"),
                        Type = "text/html"
                    },
                    Status = new Url
                    {
                        Href = new Uri("https://www.mollie.com/paymentscreen/banktransfer/status/fgnwdh"),
                        Type = "text/html"
                    },
                    PayOnline = new Url
                    {
                        Href = new Uri("https://www.mollie.com/paymentscreen/banktransfer/pay-online/fgnwdh"),
                        Type = "text/html"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/orders-api/create-order-payment"),
                        Type = "text/html"
                    }
                }

            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_stTC2WHAuS");

            var payment = await _apiClient.OrderPayments.CreateFor(order, new Payment
            {
                Method = "banktransfer"
            });

            Assert.IsNotNull(payment);
            Assert.IsInstanceOfType(payment, typeof(Payment));
            Assert.AreEqual("payment", payment.Resource);
            Assert.AreEqual("tr_WDqYK6vllg", payment.Id);
            Assert.AreEqual("test", payment.Mode);
            Assert.AreEqual(new Amount("698.00", "EUR"), payment.Amount);
            Assert.AreEqual("open", payment.Status);
            Assert.AreEqual(PaymentStatus.STATUS_OPEN, payment.Status);
            Assert.AreEqual("Order #1337 (Lego cars)", payment.Description);
            Assert.AreEqual(new DateTime(2018, 12, 1, 17, 9, 2), payment.CreatedAt);
            Assert.AreEqual(PaymentMethod.BANKTRANSFER, payment.Method);
            Assert.IsNull(payment.Metadata);
            Assert.AreEqual("ord_stTC2WHAuS", payment.OrderId);
            Assert.IsTrue(payment.IsCancelable);
            Assert.AreEqual(new CultureInfo("nl_NL"), payment.Locale);
            Assert.AreEqual("pfl_URR55HPMGx", payment.ProfileId);
            Assert.AreEqual(SequenceType.SEQUENCETYPE_ONEOFF, payment.SequenceType);
            Assert.AreEqual(new Amount("698.00", "EUR"), payment.SettlementAmount);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_WDqYK6vllg", "application/hal+json"), payment.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/orders/ord_stTC2WHAuS", "application/hal+json"), payment.Links.Order);
            Assert.AreEqual(new Url("https://www.mollie.com/paymentscreen/banktransfer/status/fgnwdh", "text/html"), payment.Links.Status);
            Assert.AreEqual(new Url("https://www.mollie.com/paymentscreen/banktransfer/pay-online/fgnwdh", "text/html"), payment.Links.PayOnline);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/orders-api/create-order-payment", "text/html"), payment.Links.Documentation);
        }
    }
}
