﻿using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class IDealPayment : Payment
    {
        [DataMember(Name = "issuer", EmitDefaultValue = false, IsRequired = false)]
        public string Issuer { private get; set; }

        public IDealPayment()
        {
            Method = PaymentMethod.IDEAL;
        }
    }
}
