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
    public class SettlementEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetSettlement()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/settlements/stl_xcaSGAHuRt")
            };

            var responseContent = new Settlement
            {
                Resource = "settlement",
                Id = "stl_xcaSGAHuRt",
                Reference = "1234567.1234.12",
                CreatedAt = new DateTime(2018, 4, 30, 4, 0, 2),
                SettledAt = new DateTime(2018, 5, 1, 4, 0, 2),
                Status = "pending",
                Amount = new Amount
                {
                    Value = "1980.98",
                    Currency = "EUR"
                },
                Periods = new Dictionary<string, Dictionary<string, SettlementPeriod>>
                {
                    {
                        "2018", new Dictionary<string, SettlementPeriod>
                        {
                            {  "04", new SettlementPeriod
                                {
                                    Revenue = new SettlementPeriodRevenue[]
                                    {
                                        new SettlementPeriodRevenue
                                        {
                                            Description = "Creditcard",
                                            Method = "creditcard",
                                            Count = 2,
                                            AmountNet = new Amount
                                            {
                                                Value = "790.00",
                                                Currency = "EUR"
                                            },
                                            AmountVat = null,
                                            AmountGross =  new Amount
                                            {
                                                Value = "1000.00",
                                                Currency = "EUR"
                                            }
                                        },
                                        new SettlementPeriodRevenue
                                        {
                                            Description = "iDEAL",
                                            Method = "ideal",
                                            Count = 2,
                                            AmountNet = new Amount
                                            {
                                                Value = "790.00",
                                                Currency = "EUR"
                                            },
                                            AmountVat = null,
                                            AmountGross =  new Amount
                                            {
                                                Value = "1000.00",
                                                Currency = "EUR"
                                            }
                                        }
                                    },
                                    Costs = new SettlementPeriodCost[]
                                    {
                                        new SettlementPeriodCost
                                        {
                                            Description = "Creditcard",
                                            Method = "creditcard",
                                            Count = 2,
                                            Rate = new SettlementPeriodCostRate
                                            {
                                                Fixed = new Amount
                                                {
                                                    Value = "0.00",
                                                    Currency = "EUR"
                                                },
                                                Variable = "1.80"
                                            },
                                            AmountNet = new Amount
                                            {
                                                Value = "14.22",
                                                Currency = "EUR"
                                            },
                                            AmountVat = new Amount
                                            {
                                                Value = "2.9862",
                                                Currency = "EUR"
                                            },
                                            AmountGross =  new Amount
                                            {
                                                Value = "17.2062",
                                                Currency = "EUR"
                                            }
                                        },
                                        new SettlementPeriodCost
                                        {
                                            Description = "Fixed creditcard costs",
                                            Method = "creditcard",
                                            Count = 2,
                                            Rate = new SettlementPeriodCostRate
                                            {
                                                Fixed = new Amount
                                                {
                                                    Value = "0.25",
                                                    Currency = "EUR"
                                                },
                                                Variable = "0"
                                            },
                                            AmountNet = new Amount
                                            {
                                                Value = "0.50",
                                                Currency = "EUR"
                                            },
                                            AmountVat = new Amount
                                            {
                                                Value = "0.105",
                                                Currency = "EUR"
                                            },
                                            AmountGross =  new Amount
                                            {
                                                Value = "0.605",
                                                Currency = "EUR"
                                            }
                                        },
                                        new SettlementPeriodCost
                                        {
                                            Description = "Fixed iDEAL costs",
                                            Method = "ideal",
                                            Count = 2,
                                            Rate = new SettlementPeriodCostRate
                                            {
                                                Fixed = new Amount
                                                {
                                                    Value = "0.25",
                                                    Currency = "EUR"
                                                },
                                                Variable = "0"
                                            },
                                            AmountNet = new Amount
                                            {
                                                Value = "0.50",
                                                Currency = "EUR"
                                            },
                                            AmountVat = new Amount
                                            {
                                                Value = "0.105",
                                                Currency = "EUR"
                                            },
                                            AmountGross =  new Amount
                                            {
                                                Value = "0.605",
                                                Currency = "EUR"
                                            }
                                        },
                                        new SettlementPeriodCost
                                        {
                                            Description = "Refunds iDEAL",
                                            Method = "refund",
                                            Count = 2,
                                            Rate = new SettlementPeriodCostRate
                                            {
                                                Fixed = new Amount
                                                {
                                                    Value = "0.25",
                                                    Currency = "EUR"
                                                },
                                                Variable = "0"
                                            },
                                            AmountNet = new Amount
                                            {
                                                Value = "0.50",
                                                Currency = "EUR"
                                            },
                                            AmountVat = new Amount
                                            {
                                                Value = "0.105",
                                                Currency = "EUR"
                                            },
                                            AmountGross =  new Amount
                                            {
                                                Value = "0.605",
                                                Currency = "EUR"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                InvoiceId = "inv_VseyTUhJSy",
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/payments"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/refunds"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/chargebacks"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/settlements-api/get-settlement"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var settlement = await _apiClient.Settlements.Get("stl_xcaSGAHuRt");

            Assert.IsInstanceOfType(settlement, typeof(Settlement));
            Assert.AreEqual("settlement", settlement.Resource);
            Assert.AreEqual("stl_xcaSGAHuRt", settlement.Id);
            Assert.AreEqual("1234567.1234.12", settlement.Reference);
            Assert.AreEqual(new DateTime(2018, 4, 30, 4, 0, 2), settlement.CreatedAt);
            Assert.AreEqual(new DateTime(2018, 5, 1, 4, 0, 2), settlement.SettledAt);
            Assert.AreEqual(SettlementStatus.STATUS_PENDING, settlement.Status);
            Assert.IsNotNull(settlement.Periods);
            Assert.AreEqual("inv_VseyTUhJSy", settlement.InvoiceId);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt", "application/hal+json"), settlement.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/payments", "application/hal+json"), settlement.Links.Payments);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/refunds", "application/hal+json"), settlement.Links.Refunds);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/chargebacks", "application/hal+json"), settlement.Links.Chargebacks);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/settlements-api/get-settlement", "text/html"), settlement.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListSettlement()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/settlements")
            };

            var responseContent = new SettlementCollection
            {
                new Settlement
                {
                    Resource = "settlement",
                    Id = "stl_xcaSGAHuRt",
                    Reference = "1234567.1234.12",
                    CreatedAt = new DateTime(2018, 4, 30, 4, 0, 2),
                    SettledAt = new DateTime(2018, 5, 1, 4, 0, 2),
                    Status = "pending",
                    Amount = new Amount
                    {
                        Value = "1980.98",
                        Currency = "EUR"
                    },
                    Periods = new Dictionary<string, Dictionary<string, SettlementPeriod>>
                    {
                        {
                            "2018", new Dictionary<string, SettlementPeriod>
                            {
                                {  "04", new SettlementPeriod
                                    {
                                        Revenue = new SettlementPeriodRevenue[]
                                        {
                                            new SettlementPeriodRevenue
                                            {
                                                Description = "Creditcard",
                                                Method = "creditcard",
                                                Count = 2,
                                                AmountNet = new Amount
                                                {
                                                    Value = "790.00",
                                                    Currency = "EUR"
                                                },
                                                AmountVat = null,
                                                AmountGross =  new Amount
                                                {
                                                    Value = "1000.00",
                                                    Currency = "EUR"
                                                }
                                            },
                                            new SettlementPeriodRevenue
                                            {
                                                Description = "iDEAL",
                                                Method = "ideal",
                                                Count = 2,
                                                AmountNet = new Amount
                                                {
                                                    Value = "790.00",
                                                    Currency = "EUR"
                                                },
                                                AmountVat = null,
                                                AmountGross =  new Amount
                                                {
                                                    Value = "1000.00",
                                                    Currency = "EUR"
                                                }
                                            }
                                        },
                                        Costs = new SettlementPeriodCost[]
                                        {
                                            new SettlementPeriodCost
                                            {
                                                Description = "Creditcard",
                                                Method = "creditcard",
                                                Count = 2,
                                                Rate = new SettlementPeriodCostRate
                                                {
                                                    Fixed = new Amount
                                                    {
                                                        Value = "0.00",
                                                        Currency = "EUR"
                                                    },
                                                    Variable = "1.80"
                                                },
                                                AmountNet = new Amount
                                                {
                                                    Value = "14.22",
                                                    Currency = "EUR"
                                                },
                                                AmountVat = new Amount
                                                {
                                                    Value = "2.9862",
                                                    Currency = "EUR"
                                                },
                                                AmountGross =  new Amount
                                                {
                                                    Value = "17.2062",
                                                    Currency = "EUR"
                                                }
                                            },
                                            new SettlementPeriodCost
                                            {
                                                Description = "Fixed creditcard costs",
                                                Method = "creditcard",
                                                Count = 2,
                                                Rate = new SettlementPeriodCostRate
                                                {
                                                    Fixed = new Amount
                                                    {
                                                        Value = "0.25",
                                                        Currency = "EUR"
                                                    },
                                                    Variable = "0"
                                                },
                                                AmountNet = new Amount
                                                {
                                                    Value = "0.50",
                                                    Currency = "EUR"
                                                },
                                                AmountVat = new Amount
                                                {
                                                    Value = "0.105",
                                                    Currency = "EUR"
                                                },
                                                AmountGross =  new Amount
                                                {
                                                    Value = "0.605",
                                                    Currency = "EUR"
                                                }
                                            },
                                            new SettlementPeriodCost
                                            {
                                                Description = "Fixed iDEAL costs",
                                                Method = "ideal",
                                                Count = 2,
                                                Rate = new SettlementPeriodCostRate
                                                {
                                                    Fixed = new Amount
                                                    {
                                                        Value = "0.25",
                                                        Currency = "EUR"
                                                    },
                                                    Variable = "0"
                                                },
                                                AmountNet = new Amount
                                                {
                                                    Value = "0.50",
                                                    Currency = "EUR"
                                                },
                                                AmountVat = new Amount
                                                {
                                                    Value = "0.105",
                                                    Currency = "EUR"
                                                },
                                                AmountGross =  new Amount
                                                {
                                                    Value = "0.605",
                                                    Currency = "EUR"
                                                }
                                            },
                                            new SettlementPeriodCost
                                            {
                                                Description = "Refunds iDEAL",
                                                Method = "refund",
                                                Count = 2,
                                                Rate = new SettlementPeriodCostRate
                                                {
                                                    Fixed = new Amount
                                                    {
                                                        Value = "0.25",
                                                        Currency = "EUR"
                                                    },
                                                    Variable = "0"
                                                },
                                                AmountNet = new Amount
                                                {
                                                    Value = "0.50",
                                                    Currency = "EUR"
                                                },
                                                AmountVat = new Amount
                                                {
                                                    Value = "0.105",
                                                    Currency = "EUR"
                                                },
                                                AmountGross =  new Amount
                                                {
                                                    Value = "0.605",
                                                    Currency = "EUR"
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    },
                    InvoiceId = "inv_VseyTUhJSy",
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt"),
                            Type = "application/hal+json"
                        },
                        Payments = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/payments"),
                            Type = "application/hal+json"
                        },
                        Refunds = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/refunds"),
                            Type = "application/hal+json"
                        },
                        Chargebacks = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/settlements/stl_xcaSGAHuRt/chargebacks"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/settlements-api/get-settlement"),
                            Type = "text/html"
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/settlements-api/list-settlements"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.nl/v2/settlements"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = new Url
                {
                    Href = new Uri("https://api.mollie.nl/v2/settlements?from=stl_xcaSGAHuRt&limit=1&previous=stl_xcaPACKpLs"),
                    Type = "application/hal+json"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var settlements = await _apiClient.Settlements.Page();
            Assert.IsInstanceOfType(settlements, typeof(SettlementCollection));

            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/settlements-api/list-settlements", "text/html"), settlements.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.nl/v2/settlements", "application/hal+json"), settlements.Links.Self);
            Assert.IsNull(settlements.Links.Previous);
            Assert.AreEqual(new Url("https://api.mollie.nl/v2/settlements?from=stl_xcaSGAHuRt&limit=1&previous=stl_xcaPACKpLs", "application/hal+json"), settlements.Links.Next);

            foreach (var settlement in settlements)
            {
                Assert.IsInstanceOfType(settlement, typeof(Settlement));
                Assert.AreEqual("settlement", settlement.Resource);
                Assert.IsNotNull(settlement.Periods);
            }
        }
    }
}
