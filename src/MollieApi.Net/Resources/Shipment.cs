using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Shipment : BaseResource
    {
        /// <summary>
        /// Id of the order.
        /// </summary>
        [DataMember(Name = "orderId", EmitDefaultValue = false, IsRequired = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// UTC datetime the shipment was created in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The order object lines contain the actual things the customer bought.
        /// </summary>
        [DataMember(Name = "lines", EmitDefaultValue = false, IsRequired = false)]
        public IList<OrderLine> Lines { get; set; }

        /// <summary>
        /// An object containing tracking details for the shipment, if available.
        /// </summary>
        [DataMember(Name = "tracking", EmitDefaultValue = false, IsRequired = false)]
        public ShipmentTracking Tracking { get; set; }

        /// <summary>
        /// An object with several URL objects relevant to the customer. Every URL object will contain an href and a type field.
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Does this shipment offer track and trace?
        /// </summary>
        /// <returns></returns>
        public bool HasTracking()
        {
            return Tracking != null;
        }

        /// <summary>
        /// Does this shipment offer a track and trace code?
        /// </summary>
        /// <returns></returns>
        public bool HasTrackingUrl()
        {
            return HasTracking() && Tracking.Url != null;
        }

        /// <summary>
        /// Retrieve the track and trace url. Returns null if there is no url available.
        /// </summary>
        /// <returns></returns>
        public string GetTrackingUrl()
        {
            if (!HasTrackingUrl())
                return null;

            return Tracking.Url.ToString();
        }
    }
}
