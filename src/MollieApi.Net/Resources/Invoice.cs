using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Invoice : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reference", EmitDefaultValue = false, IsRequired = false)]
        public string Reference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "vatNumber", EmitDefaultValue = false, IsRequired = false)]
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// Date the invoice was issued, e.g. 2018-01-01
        /// </summary>
        [DataMember(Name = "issuedAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime IssuedAt { get; set; }

        /// <summary>
        /// Date the invoice was paid, e.g. 2018-01-01
        /// </summary>
        [DataMember(Name = "paidAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime PaidAt { get; set; }

        /// <summary>
        /// Date the invoice was paid, e.g. 2018-01-01
        /// </summary>
        [DataMember(Name = "dueAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime DueAt { get; set; }

        /// <summary>
        /// Amount object containing the total amount of the invoice excluding VAT.
        /// </summary>
        [DataMember(Name = "netAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount NetAmount { get; set; }

        /// <summary>
        /// Amount object containing the VAT amount of the invoice. Only for merchants registered in the Netherlands.
        /// </summary>
        [DataMember(Name = "vatAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount VatAmount { get; set; }

        /// <summary>
        /// Total amount of the invoice including VAT.
        /// </summary>
        [DataMember(Name = "grossAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount GrossAmount { get; set; }

        /// <summary>
        /// Object containing the invoice lines.
        /// See https://docs.mollie.com/reference/v2/invoices-api/get-invoice for reference
        /// </summary>
        [DataMember(Name = "lines", EmitDefaultValue = false, IsRequired = false)]
        public List<InvoiceLine> Lines { get; set; }

        /// <summary>
        /// Contains a PDF to the Invoice
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        public bool IsPaid()
        {
            return Status == InvoiceStatus.STATUS_PAID;
        }

        public bool IsOpen()
        {
            return Status == InvoiceStatus.STATUS_OPEN;
        }

        public bool IsOverdue()
        {
            return Status == InvoiceStatus.STATUS_OVERDUE;
        }
    }
}
