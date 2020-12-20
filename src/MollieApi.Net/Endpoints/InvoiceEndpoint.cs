using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class InvoiceEndpoint : CollectionEndpointAbstract<Invoice, InvoiceCollection>
    {
        public InvoiceEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("invoices");
        }

        /// <summary>
        /// Retrieve an Invoice from Mollie.
        /// 
        /// Will throw a ApiException if the invoice id is invalid or the resource cannot be found.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<Invoice> Get(string invoiceId, Dictionary<string, string> parameters = null)
        {
            return await RestRead(invoiceId, parameters);
        }

        /// <summary>
        /// Retrieves a collection of Invoices from Mollie.
        /// </summary>
        /// <param name="from">The first invoice ID you want to include in your list.</param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<InvoiceCollection> Page(string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await RestList(from, limit, parameters);
        }

        /// <summary>
        /// This is a wrapper method for page
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<InvoiceCollection> All(Dictionary<string, string> parameters = null)
        {
            return await Page(null, null, parameters);
        }
    }
}
