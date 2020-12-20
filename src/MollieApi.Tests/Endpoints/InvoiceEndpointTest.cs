using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class InvoiceEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetInvoice()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/invoices/inv_bsa6PvAwaK")
            };

            var content = new Invoice
            {
                Resource = "invoice",
                Id = "inv_bsa6PvAwaK",
                Reference = "2018.190241",
                VatNumber = "123456789B01",
                Status = "paid",
                IssuedAt = new DateTime(2018, 5, 2),
                PaidAt = new DateTime(2018, 5, 2),
                NetAmount = new Amount
                {
                    Value = "100.00",
                    Currency = "EUR"
                },
                VatAmount = new Amount
                {
                    Value = "0.00",
                    Currency = "EUR"
                },
                GrossAmount = new Amount
                {
                    Value = "100.00",
                    Currency = "EUR"
                },
                Lines = new List<InvoiceLine>
                {
                    new InvoiceLine
                    {
                        Period = "2018-04",
                        Description = "iDEAL transaction costs: april 2018",
                        Count = 1337,
                        VatPercentage = 0,
                        Amount = new Amount
                        {
                            Value = "50.00",
                            Currency = "EUR"
                        }
                    },
                    new InvoiceLine
                    {
                        Period = "2018-04",
                        Description = "Refunds iDEAL: april 2018",
                        Count = 1337,
                        VatPercentage = 0,
                        Amount = new Amount
                        {
                            Value = "50.00",
                            Currency = "EUR"
                        }
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/invoices/inv_bsa6PvAwaK"),
                        Type = "application/hal+json"
                    },
                    Pdf = new Url
                    {
                        Href = new Uri("https://www.mollie.com/merchant/download/invoice/bsa6PvAwaK/79aa10f49132b7844c0243648ade6985"),
                        Type = "application/pdf"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/invoices-api/get-invoice"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var invoice = await _apiClient.Invoices.Get("inv_bsa6PvAwaK");

            Assert.IsInstanceOfType(invoice, typeof(Invoice));
            Assert.AreEqual("invoice", invoice.Resource);
            Assert.AreEqual("inv_bsa6PvAwaK", invoice.Id);
            Assert.AreEqual("2018.190241", invoice.Reference);
            Assert.AreEqual("123456789B01", invoice.VatNumber);
            Assert.AreEqual(InvoiceStatus.STATUS_PAID, invoice.Status);
            Assert.AreEqual(new DateTime(2018, 5, 2), invoice.IssuedAt);
            Assert.AreEqual(new DateTime(2018, 5, 2), invoice.PaidAt);
            Assert.AreEqual(new Amount("100.00", "EUR"), invoice.NetAmount);
            Assert.AreEqual(new Amount("0.00", "EUR"), invoice.VatAmount);
            Assert.AreEqual(new Amount("100.00", "EUR"), invoice.GrossAmount);
            Assert.AreEqual(2, invoice.Lines.Count);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/invoices/inv_bsa6PvAwaK", "application/hal+json"), invoice.Links.Self);
            Assert.AreEqual(new Url("https://www.mollie.com/merchant/download/invoice/bsa6PvAwaK/79aa10f49132b7844c0243648ade6985", "application/pdf"), invoice.Links.Pdf);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/invoices-api/get-invoice", "text/html"), invoice.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListInvoices()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/invoices")
            };

            var content = new InvoiceCollection
            {
                new Invoice {
                    Resource = "invoice",
                    Id = "inv_bsa6PvAwaK",
                    Reference = "2018.190241",
                    VatNumber = "123456789B01",
                    Status = "paid",
                    IssuedAt = new DateTime(2018, 5, 2),
                    PaidAt = new DateTime(2018, 5, 2),
                    NetAmount = new Amount
                    {
                        Value = "100.00",
                        Currency = "EUR"
                    },
                    VatAmount = new Amount
                    {
                        Value = "0.00",
                        Currency = "EUR"
                    },
                    GrossAmount = new Amount
                    {
                        Value = "100.00",
                        Currency = "EUR"
                    },
                    Lines = new List<InvoiceLine>
                    {
                        new InvoiceLine
                        {
                            Period = "2018-04",
                            Description = "iDEAL transaction costs: april 2018",
                            Count = 1337,
                            VatPercentage = 0,
                            Amount = new Amount
                            {
                                Value = "50.00",
                                Currency = "EUR"
                            }
                        },
                        new InvoiceLine
                        {
                            Period = "2018-04",
                            Description = "Refunds iDEAL: april 2018",
                            Count = 1337,
                            VatPercentage = 0,
                            Amount = new Amount
                            {
                                Value = "50.00",
                                Currency = "EUR"
                            }
                        }
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/invoices/inv_bsa6PvAwaK"),
                            Type = "application/hal+json"
                        },
                        Pdf = new Url
                        {
                            Href = new Uri("https://www.mollie.com/merchant/download/invoice/bsa6PvAwaK/79aa10f49132b7844c0243648ade6985"),
                            Type = "application/pdf"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/invoices-api/get-invoice"),
                            Type = "text/html"
                        }
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/invoices-api/list-invoices"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.nl/v2/invoices?limit=50"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = null
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var invoices = await _apiClient.Invoices.Page();

            Assert.IsInstanceOfType(invoices, typeof(InvoiceCollection));
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/invoices-api/list-invoices", "text/html"), invoices.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.nl/v2/invoices?limit=50", "application/hal+json"), invoices.Links.Self);
            Assert.IsNull(invoices.Links.Previous);
            Assert.IsNull(invoices.Links.Next);

            foreach (var invoice in invoices)
            {
                Assert.IsInstanceOfType(invoice, typeof(Invoice));
                Assert.AreEqual("invoice", invoice.Resource);
                Assert.IsNotNull(invoice.Lines);
            }
        }
    }
}
