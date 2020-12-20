using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ShipmentTracking
    {
        [DataMember(Name = "carrier", EmitDefaultValue = false, IsRequired = false)]
        public string Carrier { get; set; }

        [DataMember(Name = "code", EmitDefaultValue = false, IsRequired = false)]
        public string Code { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false, IsRequired = false)]
        public Uri Url { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is ShipmentTracking tracking)) return false;
            if (!Equals(tracking.Carrier, Carrier)) return false;
            if (!Equals(tracking.Code, Code)) return false;
            if (!Equals(tracking.Url, Url)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -1759569799;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Carrier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<Uri>.Default.GetHashCode(Url);
            return hashCode;
        }
    }
}
