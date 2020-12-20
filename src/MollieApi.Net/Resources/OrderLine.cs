using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class OrderLine : BaseResource
    {
        /// <summary>
        /// The ID of the order this line belongs to.
        /// </summary>
        [DataMember(Name = "orderId", EmitDefaultValue = false, IsRequired = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// The type of product bought.
        /// </summary>
        [DataMember(Name = "type", EmitDefaultValue = false, IsRequired = false)]
        public string Type { get; set; }

        /// <summary>
        /// A description of the order line.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }

        /// <summary>
        /// The status of the order line.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// Can this order line be canceled?
        /// </summary>
        [DataMember(Name = "isCancelable", EmitDefaultValue = false, IsRequired = false)]
        public bool IsCancelable { get; set; }

        /// <summary>
        /// Can this order line be canceled?
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false, IsRequired = false)]
        public int Quantity { get; set; }

        /// <summary>
        /// The price of a single item in the order line.
        /// </summary>
        [DataMember(Name = "unitPrice", EmitDefaultValue = false, IsRequired = false)]
        public Amount UnitPrice { get; set; }

        /// <summary>
        /// Any discounts applied to the order line.
        /// </summary>
        [DataMember(Name = "discountAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount DiscountAmount { get; set; }

        /// <summary>
        /// The total amount of the line, including VAT and discounts.
        /// </summary>
        [DataMember(Name = "totalAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount TotalAmount { get; set; }

        /// <summary>
        /// The VAT rate applied to the order line. It is defined as a string and not as a float to ensure the correct number of decimals are passed.
        /// </summary>
        [DataMember(Name = "vatRate", EmitDefaultValue = false, IsRequired = false)]
        public string VatRate { get; set; }

        /// <summary>
        /// The amount of value-added tax on the line.
        /// </summary>
        [DataMember(Name = "vatAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount VatAmount { get; set; }

        /// <summary>
        /// The SKU, EAN, ISBN or UPC of the product sold.
        /// </summary>
        [DataMember(Name = "sku", EmitDefaultValue = false, IsRequired = false)]
        public string SKU { get; set; }

        /// <summary>
        /// A link pointing to an image of the product sold.
        /// </summary>
        [DataMember(Name = "imageUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// A link pointing to the product page in your web shop of the product sold.
        /// </summary>
        [DataMember(Name = "productUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri ProductUrl { get; set; }

        /// <summary>
        /// During creation of the order you can set custom metadata on order lines that is stored with the order, and given back whenever you retrieve that order line.
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// The order line's date and time of creation, in ISO 8601 format.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Is this order line created?
        /// </summary>
        /// <returns></returns>
        public bool IsCreated()
        {
            return Status == OrderLineStatus.STATUS_CREATED;
        }

        /// <summary>
        /// Is this order line paid for?
        /// </summary>
        /// <returns></returns>
        public bool IsPaid()
        {
            return Status == OrderLineStatus.STATUS_PAID;
        }

        /// <summary>
        /// Is this order line authorized?
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized()
        {
            return Status == OrderLineStatus.STATUS_AUTHORIZED;
        }

        /// <summary>
        /// Is this order line canceled?
        /// </summary>
        /// <returns></returns>
        public bool IsCanceled()
        {
            return Status == OrderLineStatus.STATUS_CANCELED;
        }

        /// <summary>
        /// Is this order line refunded?
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public bool IsRefunded()
        {
            return Status == OrderLineStatus.STATUS_REFUNDED;
        }

        /// <summary>
        /// Is this order line shipping?
        /// </summary>
        /// <returns></returns>
        public bool IsShipping()
        {
            return Status == OrderLineStatus.STATUS_SHIPPING;
        }

        /// <summary>
        /// Is this order line completed?
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            return Status == OrderLineStatus.STATUS_COMPLETED;
        }

        /// <summary>
        /// Is this order line for a physical product?
        /// </summary>
        /// <returns></returns>
        public bool IsPhysical()
        {
            return Type == OrderLineType.TYPE_PHYSICAL;
        }

        /// <summary>
        /// Is this order line for applying a discount?
        /// </summary>
        /// <returns></returns>
        public bool IsDiscount()
        {
            return Type == OrderLineType.TYPE_DISCOUNT;
        }

        /// <summary>
        /// Is this order line for a digital product?
        /// </summary>
        /// <returns></returns>
        public bool IsDigital()
        {
            return Type == OrderLineType.TYPE_DIGITAL;
        }

        /// <summary>
        /// Is this order line for applying a shipping fee?
        /// </summary>
        /// <returns></returns>
        public bool IsShippingFee()
        {
            return Type == OrderLineType.TYPE_SHIPPING_FEE;
        }

        /// <summary>
        /// Is this order line for store credit?
        /// </summary>
        /// <returns></returns>
        public bool IsStoreCredit()
        {
            return Type == OrderLineType.TYPE_STORE_CREDIT;
        }

        /// <summary>
        /// Is this order line for a gift card?
        /// </summary>
        /// <returns></returns>
        public bool IsGiftCard()
        {
            return Type == OrderLineType.TYPE_GIFT_CARD;
        }

        /// <summary>
        /// Is this order line for a surcharge?
        /// </summary>
        /// <returns></returns>
        public bool IsSurcharge()
        {
            return Type == OrderLineType.TYPE_SURCHARGE;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is OrderLine line)) return false;
            if (!base.Equals(line)) return false;
            if (!Equals(line.OrderId, OrderId)) return false;
            if (!Equals(line.Type, Type)) return false;
            if (!Equals(line.Name, Name)) return false;
            if (!Equals(line.Status, Status)) return false;
            if (!Equals(line.IsCancelable, IsCancelable)) return false;
            if (!Equals(line.Quantity, Quantity)) return false;
            if (!Equals(line.UnitPrice, UnitPrice)) return false;
            if (!Equals(line.DiscountAmount, DiscountAmount)) return false;
            if (!Equals(line.TotalAmount, TotalAmount)) return false;
            if (!Equals(line.VatRate, VatRate)) return false;
            if (!Equals(line.VatAmount, VatAmount)) return false;
            if (!Equals(line.SKU, SKU)) return false;
            if (!Equals(line.ImageUrl, ImageUrl)) return false;
            if (!Equals(line.ProductUrl, ProductUrl)) return false;
            if (!Equals(line.Metadata, Metadata)) return false;
            if (!Equals(line.CreatedAt, CreatedAt)) return false;
            if (!Equals(line.Links, Links)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 844994850;
            hashCode *= base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrderId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            hashCode = hashCode * -1521134295 + IsCancelable.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Amount>.Default.GetHashCode(UnitPrice);
            hashCode = hashCode * -1521134295 + EqualityComparer<Amount>.Default.GetHashCode(DiscountAmount);
            hashCode = hashCode * -1521134295 + EqualityComparer<Amount>.Default.GetHashCode(TotalAmount);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(VatRate);
            hashCode = hashCode * -1521134295 + EqualityComparer<Amount>.Default.GetHashCode(VatAmount);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SKU);
            hashCode = hashCode * -1521134295 + EqualityComparer<Uri>.Default.GetHashCode(ImageUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<Uri>.Default.GetHashCode(ProductUrl);
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<string, string>>.Default.GetHashCode(Metadata);
            hashCode = hashCode * -1521134295 + CreatedAt.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Links>.Default.GetHashCode(Links);
            return hashCode;
        }
    }
}
