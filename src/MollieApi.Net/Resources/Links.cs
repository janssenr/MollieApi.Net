using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Links
    {
        [DataMember(Name = "self", EmitDefaultValue = false)]
        public Url Self { get; set; }

        [DataMember(Name = "next", EmitDefaultValue = false)]
        public Url Next { get; set; }

        [DataMember(Name = "previous", EmitDefaultValue = false)]
        public Url Previous { get; set; }

        [DataMember(Name = "first", EmitDefaultValue = false)]
        public Url First { get; set; }

        [DataMember(Name = "last", EmitDefaultValue = false)]
        public Url Last { get; set; }

        [DataMember(Name = "captures", EmitDefaultValue = false)]
        public Url Captures { get; set; }

        [DataMember(Name = "chargebacks", EmitDefaultValue = false)]
        public Url Chargebacks { get; set; }

        [DataMember(Name = "checkout", EmitDefaultValue = false)]
        public Url Checkout { get; set; }

        [DataMember(Name = "checkoutPreviewUrl", EmitDefaultValue = false)]
        public Url CheckoutPreviewUrl { get; set; }

        [DataMember(Name = "customer", EmitDefaultValue = false)]
        public Url Customer { get; set; }

        [DataMember(Name = "dashboard", EmitDefaultValue = false)]
        public Url Dashboard { get; set; }

        [DataMember(Name = "documentation", EmitDefaultValue = false)]
        public Url Documentation { get; set; }

        [DataMember(Name = "methods", EmitDefaultValue = false)]
        public Url Methods { get; set; }

        [DataMember(Name = "order", EmitDefaultValue = false)]
        public Url Order { get; set; }

        [DataMember(Name = "organization", EmitDefaultValue = false)]
        public Url Organization { get; set; }

        [DataMember(Name = "payment", EmitDefaultValue = false)]
        public Url Payment { get; set; }

        [DataMember(Name = "payments", EmitDefaultValue = false)]
        public Url Payments { get; set; }

        [DataMember(Name = "payOnline", EmitDefaultValue = false)]
        public Url PayOnline { get; set; }

        [DataMember(Name = "pdf", EmitDefaultValue = false)]
        public Url Pdf { get; set; }

        [DataMember(Name = "refunds", EmitDefaultValue = false)]
        public Url Refunds { get; set; }

        [DataMember(Name = "settlement", EmitDefaultValue = false)]
        public Url Settlement { get; set; }

        [DataMember(Name = "shipment", EmitDefaultValue = false)]
        public Url Shipment { get; set; }

        [DataMember(Name = "status", EmitDefaultValue = false)]
        public Url Status { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Links links)) return false;
            if (!Equals(links.Self, Self)) return false;
            if (!Equals(links.Next, Next)) return false;
            if (!Equals(links.Previous, Previous)) return false;
            if (!Equals(links.First, First)) return false;
            if (!Equals(links.Last, Last)) return false;
            if (!Equals(links.Captures, Captures)) return false;
            if (!Equals(links.Chargebacks, Chargebacks)) return false;
            if (!Equals(links.Checkout, Checkout)) return false;
            if (!Equals(links.Customer, Customer)) return false;
            if (!Equals(links.Dashboard, Dashboard)) return false;
            if (!Equals(links.Documentation, Documentation)) return false;
            if (!Equals(links.Methods, Methods)) return false;
            if (!Equals(links.Order, Order)) return false;
            if (!Equals(links.Organization, Organization)) return false;
            if (!Equals(links.Payment, Payment)) return false;
            if (!Equals(links.Payments, Payments)) return false;
            if (!Equals(links.PayOnline, PayOnline)) return false;
            if (!Equals(links.Pdf, Pdf)) return false;
            if (!Equals(links.Refunds, Refunds)) return false;
            if (!Equals(links.Settlement, Settlement)) return false;
            if (!Equals(links.Shipment, Shipment)) return false;
            if (!Equals(links.Status, Status)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -569487649;
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Self);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Next);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Previous);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(First);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Last);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Captures);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Chargebacks);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Checkout);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Customer);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Dashboard);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Documentation);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Methods);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Organization);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Payment);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Payments);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Pdf);
            hashCode = hashCode * -1521134295 + EqualityComparer<Url>.Default.GetHashCode(Refunds);
            return hashCode;
        }
    }
}
