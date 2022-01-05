using MollieApi.Net.Endpoints;
using MollieApi.Net.Exceptions;
using MollieApi.Net.Extensions;
using MollieApi.Net.Helpers;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MollieApi.Net
{
    public class MollieApiClient
    {
        /// <summary>
        /// Version of our client.
        /// </summary>
        private const string CLIENT_VERSION = "2.0.0";

        /// <summary>
        /// Endpoint of the remote API.
        /// </summary>
        private const string API_ENDPOINT = "https://api.mollie.com";

        /// <summary>
        /// Version of the remote API.
        /// </summary>
        private const string API_VERSION = "v2";

        /// <summary>
        /// Default response timeout (in seconds).
        /// </summary>
        private const int TIMEOUT = 10;

        private readonly HttpClient _httpClient;

        private readonly List<string> _versionString;

        private string _apiEndpoint = API_ENDPOINT;

        private string _apiKey;

        /// <summary>
        /// True if an OAuth access token is set as API key.
        /// </summary>
        private bool _oauthAccess;

        /// <summary>
        /// HTTP Methods
        /// </summary>
        public const string HTTP_GET = "GET";
        public const string HTTP_POST = "POST";
        public const string HTTP_DELETE = "DELETE";
        public const string HTTP_PATCH = "PATCH";

        /// <summary>
        /// RESTful Chargebacks resource.
        /// </summary>
        public readonly ChargebackEndpoint Chargebacks;

        /// <summary>
        /// RESTful Customers resource.
        /// </summary>
        public readonly CustomerEndpoint Customers;

        /// <summary>
        /// RESTful Customer mandates resource.
        /// </summary>
        public readonly CustomerMandateEndpoint CustomerMandates;

        /// <summary>
        /// RESTful Customer payments resource.
        /// </summary>
        public readonly CustomerPaymentsEndpoint CustomerPayments;

        /// <summary>
        /// RESTful Customer mandates resource.
        /// </summary>
        public readonly CustomerSubscriptionEndpoint CustomerSubscriptions;

        /// <summary>
        /// RESTful Invoice resource.
        /// </summary>
        public readonly InvoiceEndpoint Invoices;

        /// <summary>
        /// RESTful Methods resource.
        /// </summary>
        public readonly MethodEndpoint Methods;

        /// <summary>
        /// RESTful Onboarding resource.
        /// </summary>
        public readonly OnboardingEndpoint Onboarding;

        /// <summary>
        /// RESTful Order resource.
        /// </summary>
        public readonly OrderEndpoint Orders;

        /// <summary>
        /// RESTful OrderLine resource.
        /// </summary>
        public readonly OrderLineEndpoint OrderLines;

        /// <summary>
        /// RESTful OrderPayment resource.
        /// </summary>
        public readonly OrderPaymentEndpoint OrderPayments;

        /// <summary>
        /// RESTful Order Refunds resource.
        /// </summary>
        public readonly OrderRefundEndpoint OrderRefunds;

        /// <summary>
        /// RESTful OrderShipment resource.
        /// </summary>
        public readonly OrderShipmentEndpoint OrderShipments;

        /// <summary>
        /// RESTful Organization resource.
        /// </summary>
        public readonly OrganizationEndpoint Organizations;

        /// <summary>
        /// RESTful Payments resource.
        /// </summary>
        public readonly PaymentEndpoint Payments;

        /// <summary>
        /// RESTful Payment Captures resource.
        /// </summary>
        public readonly PaymentCaptureEndpoint PaymentCaptures;

        /// <summary>
        /// RESTful Payment Chargebacks resource.
        /// </summary>
        public readonly PaymentChargebackEndpoint PaymentChargebacks;

        /// <summary>
        /// RESTful Payment Refunds resource.
        /// </summary>
        public readonly PaymentRefundEndpoint PaymentRefunds;

        /// <summary>
        /// RESTful Permission resource.
        /// </summary>
        public readonly PermissionEndpoint Permissions;

        /// <summary>
        /// RESTful Profiles resource.
        /// </summary>
        public readonly ProfileEndpoint Profiles;

        /// <summary>
        /// RESTful Profile methods resource.
        /// </summary>
        public readonly ProfileMethodEndpoint ProfileMethods;

        /// <summary>
        /// RESTful Refunds resource.
        /// </summary>
        public readonly RefundEndpoint Refunds;

        /// <summary>
        /// RESTful Settlement resource.
        /// </summary>
        public readonly SettlementEndpoint Settlements;

        /// <summary>
        /// RESTful Settlement payment resource.
        /// </summary>
        public readonly SettlementPaymentEndpoint SettlementPayments;

        /// <summary>
        /// RESTful Subscription resource.
        /// </summary>
        public readonly SubscriptionEndpoint Subscriptions;

        /// <summary>
        /// Manages Wallet requests
        /// </summary>
        public readonly WalletEndpoint Wallets;

        public MollieApiClient() : this(new HttpClient()) { }

        public MollieApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.Timeout = TimeSpan.FromSeconds(TIMEOUT);

            Chargebacks = new ChargebackEndpoint(this);
            Customers = new CustomerEndpoint(this);
            CustomerMandates = new CustomerMandateEndpoint(this);
            CustomerPayments = new CustomerPaymentsEndpoint(this);
            CustomerSubscriptions = new CustomerSubscriptionEndpoint(this);
            Invoices = new InvoiceEndpoint(this);
            Methods = new MethodEndpoint(this);
            Onboarding = new OnboardingEndpoint(this);
            Organizations = new OrganizationEndpoint(this);
            Orders = new OrderEndpoint(this);
            OrderLines = new OrderLineEndpoint(this);
            OrderPayments = new OrderPaymentEndpoint(this);
            OrderRefunds = new OrderRefundEndpoint(this);
            OrderShipments = new OrderShipmentEndpoint(this);
            Payments = new PaymentEndpoint(this);
            PaymentCaptures = new PaymentCaptureEndpoint(this);
            PaymentChargebacks = new PaymentChargebackEndpoint(this);
            PaymentRefunds = new PaymentRefundEndpoint(this);
            Permissions = new PermissionEndpoint(this);
            Profiles = new ProfileEndpoint(this);
            ProfileMethods = new ProfileMethodEndpoint(this);
            Refunds = new RefundEndpoint(this);
            Settlements = new SettlementEndpoint(this);
            SettlementPayments = new SettlementPaymentEndpoint(this);
            Subscriptions = new SubscriptionEndpoint(this);
            Wallets = new WalletEndpoint(this);

            _versionString = new List<string>();
            AddVersionString("MollieApi.Net/" + CLIENT_VERSION);
            AddVersionString("ASP.NET/" + Environment.Version.ToString());

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public void SetApiEndPoint(string url)
        {
            _apiEndpoint = url.Trim().TrimEnd('/');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetApiEndPoint()
        {
            return _apiEndpoint;
        }

        public void SetApiKey(string apiKey)
        {
            if (!Regex.IsMatch(apiKey, @"(live|test)_\w{30,}"))
            {
                throw new ApiException($"Invalid API key: '{apiKey}'. An API key must start with 'test_' or 'live_' and must be at least 30 characters long.");
            }

            _apiKey = apiKey;
            _oauthAccess = false;
        }

        public void SetAccessToken(string accessToken)
        {
            accessToken = accessToken.Trim();

            if (!Regex.IsMatch(accessToken, @"access_\w+"))
            {
                throw new ApiException($"Invalid OAuth access token: '{accessToken}'. An access token must start with 'access_'.");
            }

            _apiKey = accessToken;
            _oauthAccess = true;
        }

        public bool UsesOAuth()
        {
            return _oauthAccess;
        }

        public void AddVersionString(string versionString)
        {
            _versionString.Add(Regex.Replace(versionString, "[ \t\n\r]", "-"));
        }

        public async Task<T> PerformHttpCall<T>(string httpMethod, string apiMethod, string httpBody = null)
        {
            string url = _apiEndpoint + "/" + API_VERSION + "/" + apiMethod;
            return await PerformHttpCallToFullUrl<T>(httpMethod, url, httpBody);
        }

        public async Task<T> PerformHttpCallToFullUrl<T>(string httpMethod, string url, string httpBody = null)
        {
            if (string.IsNullOrEmpty(_apiKey))
                throw new ApiException("You have not set an API key or OAuth access token. Please use SetApiKey() to set the API key.");

            string userAgent = string.Join(" ", _versionString);
            if (UsesOAuth())
                userAgent += " OAuth/2.0";

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);

            HttpResponseMessage response = null;
            switch (httpMethod)
            {
                case HTTP_GET:
                    {
                        response = await _httpClient.GetAsync(url).ConfigureAwait(false);
                        break;
                    }
                case HTTP_POST:
                    {
                        var content = new StringContent(httpBody);
                        content.Headers.Clear();
                        content.Headers.Add("Content-Type", "application/json");
                        //content.Headers.Add("Content-Type", "application/json;charset=utf-8");
                        response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
                        break;
                    }
                case HTTP_DELETE:
                    {
                        response = await _httpClient.DeleteAsync(url).ConfigureAwait(false);
                        break;
                    }
                case HTTP_PATCH:
                    {
                        var content = new StringContent(httpBody);
                        content.Headers.Clear();
                        content.Headers.Add("Content-Type", "application/json");
                        //content.Headers.Add("Content-Type", "application/json;charset=utf-8");
                        response = await _httpClient.PatchAsync(url, content).ConfigureAwait(false);
                        break;
                    }
            }

            if (response == null)
                throw new ApiException("Did not receive API response.");

            return await ParseResponseBody<T>(response);
        }

        private async Task<T> ParseResponseBody<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (string.IsNullOrEmpty(body))
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                        return default(T);

                    throw new ApiException("No response body found.");
                }
                try
                {
                    return JsonHelper.Deserialize<T>(body);
                }
                catch
                {
                    throw new ApiException($"Unable to decode Mollie response: '{body}'.");
                }
            }
            else
            {
                throw await ApiException.CreateFromResponse(response);
            }
        }
    }
}
