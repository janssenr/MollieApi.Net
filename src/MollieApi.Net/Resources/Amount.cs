using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Amount
    {
        [DataMember(Name = "value", EmitDefaultValue = false, IsRequired = true)]
        public string Value { get; set; }

        [DataMember(Name = "currency", EmitDefaultValue = false, IsRequired = true)]
        public string Currency { get; set; }

        public Amount() { }

        public Amount(string value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Amount amount)) return false;
            if (!Equals(amount.Value, Value)) return false;
            if (!Equals(amount.Currency, Currency)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -771160272;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Currency);
            return hashCode;
        }

        public override string ToString()
        {
            return Value + " " + Currency;
        }
    }
}
