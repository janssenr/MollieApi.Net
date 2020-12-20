using MollieApi.Net.Types;
using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class BankTransferPayment : Payment
    {
        [DataMember(Name = "billingEmail", EmitDefaultValue = false, IsRequired = false)]
        public string BillingEmail { private get; set; }

        [DataMember(Name = "dueDate", EmitDefaultValue = false, IsRequired = false)]
        public DateTime DueDate { private get; set; }

        public BankTransferPayment()
        {
            Method = PaymentMethod.BANKTRANSFER;
        }
    }
}
