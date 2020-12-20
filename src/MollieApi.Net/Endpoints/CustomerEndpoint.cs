using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class CustomerEndpoint : CollectionEndpointAbstract<Customer, CustomerCollection>
    {
        public CustomerEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("customers");
        }

        /// <summary>
        /// Creates a customer in Mollie.
        /// </summary>
        /// <param name="data">An Customer object containing details on the customer.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Customer> Create(Customer data, Dictionary<string, string> filters = null)
        {
            return await RestCreate(data, filters);
        }

        /// <summary>
        /// Updates a customer in Mollie.
        /// </summary>
        /// <param name="data">An Customer object containing details on the customer.</param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Customer> Update(Customer data, Dictionary<string, string> filters = null)
        {
            return await RestUpdate(data, filters);
        }

        /// <summary>
        /// Retrieve a single customer from Mollie.
        /// 
        /// Will throw a ApiException if the customer id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Customer> Get(string customerId, Dictionary<string, string> parameters = null)
        {
            return await RestRead(customerId, parameters);
        }

        /// <summary>
        /// Deletes the given Customer.
        /// 
        /// Will throw a ApiException if the customer id is invalid or the resource cannot be found.
        /// Returns with HTTP status No Content (204) if successful.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> Delete(string customerId)
        {
            return await RestDelete(customerId);
        }

        /// <summary>
        /// Retrieves a collection of Customers from Mollie.
        /// </summary>
        /// <param name="from">The first customer ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<CustomerCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }
    }
}
