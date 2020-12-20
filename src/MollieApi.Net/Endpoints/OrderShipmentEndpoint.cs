using MollieApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class OrderShipmentEndpoint : CollectionEndpointAbstract<Shipment, ShipmentCollection>
    {
        public OrderShipmentEndpoint(MollieApiClient client) : base(client)
        {
            SetResourcePath("orders_shipments");
        }

        /// <summary>
        /// Create a shipment for some order lines. You can provide an empty array for the "lines" option to include all unshipped lines for this order.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="shipment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Shipment> CreateFor(Order order, Shipment shipment, Dictionary<string, string> filters = null)
        {
            return await CreateForId(order.Id, shipment, filters);
        }

        /// <summary>
        /// Create a shipment for some order lines. You can provide an empty array for the "lines" option to include all unshipped lines for this order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shipment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Shipment> CreateForId(string orderId, Shipment shipment, Dictionary<string, string> filters = null)
        {
            SetParentId(orderId);

            return await RestCreate(shipment, filters);
        }

        /// <summary>
        /// Update a shipment.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="shipment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Shipment> UpdateFor(Order order, Shipment shipment, Dictionary<string, string> filters = null)
        {
            return await UpdateForId(order.Id, shipment, filters);
        }

        /// <summary>
        /// Update a shipment.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="shipment"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Shipment> UpdateForId(string orderId, Shipment shipment, Dictionary<string, string> filters = null)
        {
            SetParentId(orderId);

            return await RestUpdate(shipment, filters);
        }

        /// <summary>
        /// Retrieve a single shipment and the order lines shipped by a shipment’s ID.
        /// </summary>
        /// <param name="order"></param>
        /// <param name="mandateId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Shipment> GetFor(Order order, string shipmentId, Dictionary<string, string> filters = null)
        {
            return await GetForId(order.Id, shipmentId, filters);
        }

        /// <summary>
        /// Retrieve a single shipment and the order lines shipped by a shipment’s ID.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="mandateId"></param>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<Shipment> GetForId(string orderId, string shipmentId, Dictionary<string, string> filters = null)
        {
            SetParentId(orderId);

            return await RestRead(shipmentId, filters);
        }

        /// <summary>
        /// Return all shipments for the Order provided.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ShipmentCollection> ListFor(Order order, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            return await ListForId(order.Id, from, limit, parameters);
        }

        /// <summary>
        /// Return all shipments for the provided Order id.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="from"></param>
        /// <param name="limit"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task<ShipmentCollection> ListForId(string orderId, string from = null, int? limit = null, Dictionary<string, string> parameters = null)
        {
            SetParentId(orderId);

            return await RestList(from, limit, parameters);
        }
    }
}
