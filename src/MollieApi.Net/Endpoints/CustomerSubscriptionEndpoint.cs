using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class CustomerSubscriptionEndpoint : CollectionEndpointAbstract<Subscription, SubscriptionCollection>
    {
        public CustomerSubscriptionEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("customers_subscriptions");
        }

        /// <summary>
        /// Create a subscription for a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Subscription> CreateFor(Customer customer, Subscription subscription, Dictionary<string, string> filters = null)
        {
            return await CreateForId(customer.Id, subscription, filters);
        }

        /// <summary>
        /// Create a subscription for a Customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Subscription> CreateForId(string customerId, Subscription subscription, Dictionary<string, string> filters = null)
        {
            SetParentId(customerId);

            return await RestCreate(subscription, filters);
        }

        /// <summary>
        /// Update a subscription for a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Subscription> UpdateFor(Customer customer, Subscription subscription, Dictionary<string, string> filters = null)
        {
            return await UpdateForId(customer.Id, subscription, filters);
        }

        /// <summary>
        /// Update a subscription for a Customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="payment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Subscription> UpdateForId(string customerId, Subscription subscription, Dictionary<string, string> filters = null)
        {
            SetParentId(customerId);

            return await RestUpdate(subscription, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Subscription> GetFor(Customer customer, string subscriptionId, Dictionary<string, string> filters = null)
        {
            return await GetForId(customer.Id, subscriptionId, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Subscription> GetForId(string customerId, string subscriptionId, Dictionary<string, string> filters = null)
        {
            SetParentId(customerId);

            return await RestRead(subscriptionId, filters);
        }

        /// <summary>
        /// Return all subscriptions for the Customer provided.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<SubscriptionCollection> ListFor(Customer customer, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(customer.Id, from, limit, parameters);
        }

        /// <summary>
        /// Return all subscriptions for the provided Customer id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<SubscriptionCollection> ListForId(string customerId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(customerId);

            return await RestList(from, limit, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public async Task<Subscription> CancelFor(Customer customer, string subscriptionId)
        {
            return await CancelForId(customer.Id, subscriptionId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public async Task<Subscription> CancelForId(string customerId, string subscriptionId)
        {
            SetParentId(customerId);

            return await RestDelete(subscriptionId);
        }
    }
}
