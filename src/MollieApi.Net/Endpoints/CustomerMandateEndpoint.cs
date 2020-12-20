using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class CustomerMandateEndpoint : CollectionEndpointAbstract<Mandate, MandateCollection>
    {
        public CustomerMandateEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("customers_mandates");
        }

        /// <summary>
        /// Create a mandate for a Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="mandate"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Mandate> CreateFor(Customer customer, Mandate mandate, Dictionary<string, string> filters = null)
        {
            return await CreateForId(customer.Id, mandate, filters);
        }

        /// <summary>
        /// Create a mandate for a Customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="mandate"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Mandate> CreateForId(string customerId, Mandate mandate, Dictionary<string, string> filters = null)
        {
            SetParentId(customerId);

            return await RestCreate(mandate, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="mandateId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Mandate> GetFor(Customer customer, string mandateId, Dictionary<string, string> filters = null)
        {
            return await GetForId(customer.Id, mandateId, filters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="mandateId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Mandate> GetForId(string customerId, string mandateId, Dictionary<string, string> filters = null)
        {
            SetParentId(customerId);

            return await RestRead(mandateId, filters);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<MandateCollection> ListFor(Customer customer, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(customer.Id, from, limit, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="from">The first resource ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<MandateCollection> ListForId(string customerId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(customerId);

            return await RestList(from, limit, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="mandateId"></param>
        /// <returns></returns>
        public async Task<Mandate> RevokeFor(Customer customer, string mandateId)
        {
            return await RevokeForId(customer.Id, mandateId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="mandateId"></param>
        /// <returns></returns>
        public async Task<Mandate> RevokeForId(string customerId, string mandateId)
        {
            SetParentId(customerId);

            return await RestDelete(mandateId);
        }
    }
}
