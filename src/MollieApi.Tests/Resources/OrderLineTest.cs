using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class OrderLineTest
    {
        [TestMethod]
        public void TestOrderLineStatuses()
        {
            var orderLine = new OrderLine();

            orderLine.Status = OrderLineStatus.STATUS_CREATED;
            Assert.AreEqual(true, orderLine.IsCreated());
            Assert.AreEqual(false, orderLine.IsPaid());
            Assert.AreEqual(false, orderLine.IsAuthorized());
            Assert.AreEqual(false, orderLine.IsCanceled());
            Assert.AreEqual(false, orderLine.IsShipping());
            Assert.AreEqual(false, orderLine.IsCompleted());

            orderLine.Status = OrderLineStatus.STATUS_PAID;
            Assert.AreEqual(false, orderLine.IsCreated());
            Assert.AreEqual(true, orderLine.IsPaid());
            Assert.AreEqual(false, orderLine.IsAuthorized());
            Assert.AreEqual(false, orderLine.IsCanceled());
            Assert.AreEqual(false, orderLine.IsShipping());
            Assert.AreEqual(false, orderLine.IsCompleted());

            orderLine.Status = OrderLineStatus.STATUS_AUTHORIZED;
            Assert.AreEqual(false, orderLine.IsCreated());
            Assert.AreEqual(false, orderLine.IsPaid());
            Assert.AreEqual(true, orderLine.IsAuthorized());
            Assert.AreEqual(false, orderLine.IsCanceled());
            Assert.AreEqual(false, orderLine.IsShipping());
            Assert.AreEqual(false, orderLine.IsCompleted());

            orderLine.Status = OrderLineStatus.STATUS_CANCELED;
            Assert.AreEqual(false, orderLine.IsCreated());
            Assert.AreEqual(false, orderLine.IsPaid());
            Assert.AreEqual(false, orderLine.IsAuthorized());
            Assert.AreEqual(true, orderLine.IsCanceled());
            Assert.AreEqual(false, orderLine.IsShipping());
            Assert.AreEqual(false, orderLine.IsCompleted());

            orderLine.Status = OrderLineStatus.STATUS_SHIPPING;
            Assert.AreEqual(false, orderLine.IsCreated());
            Assert.AreEqual(false, orderLine.IsPaid());
            Assert.AreEqual(false, orderLine.IsAuthorized());
            Assert.AreEqual(false, orderLine.IsCanceled());
            Assert.AreEqual(true, orderLine.IsShipping());
            Assert.AreEqual(false, orderLine.IsCompleted());

            orderLine.Status = OrderLineStatus.STATUS_COMPLETED;
            Assert.AreEqual(false, orderLine.IsCreated());
            Assert.AreEqual(false, orderLine.IsPaid());
            Assert.AreEqual(false, orderLine.IsAuthorized());
            Assert.AreEqual(false, orderLine.IsCanceled());
            Assert.AreEqual(false, orderLine.IsShipping());
            Assert.AreEqual(true, orderLine.IsCompleted());
        }

        [TestMethod]
        public void TestOrderLineTypes()
        {
            var orderLine = new OrderLine();

            orderLine.Type = OrderLineType.TYPE_PHYSICAL;
            Assert.AreEqual(true, orderLine.IsPhysical());
            Assert.AreEqual(false, orderLine.IsDiscount());
            Assert.AreEqual(false, orderLine.IsDigital());
            Assert.AreEqual(false, orderLine.IsShippingFee());
            Assert.AreEqual(false, orderLine.IsStoreCredit());
            Assert.AreEqual(false, orderLine.IsGiftCard());
            Assert.AreEqual(false, orderLine.IsSurcharge());

            orderLine.Type = OrderLineType.TYPE_DISCOUNT;
            Assert.AreEqual(false, orderLine.IsPhysical());
            Assert.AreEqual(true, orderLine.IsDiscount());
            Assert.AreEqual(false, orderLine.IsDigital());
            Assert.AreEqual(false, orderLine.IsShippingFee());
            Assert.AreEqual(false, orderLine.IsStoreCredit());
            Assert.AreEqual(false, orderLine.IsGiftCard());
            Assert.AreEqual(false, orderLine.IsSurcharge());

            orderLine.Type = OrderLineType.TYPE_DIGITAL;
            Assert.AreEqual(false, orderLine.IsPhysical());
            Assert.AreEqual(false, orderLine.IsDiscount());
            Assert.AreEqual(true, orderLine.IsDigital());
            Assert.AreEqual(false, orderLine.IsShippingFee());
            Assert.AreEqual(false, orderLine.IsStoreCredit());
            Assert.AreEqual(false, orderLine.IsGiftCard());
            Assert.AreEqual(false, orderLine.IsSurcharge());

            orderLine.Type = OrderLineType.TYPE_SHIPPING_FEE;
            Assert.AreEqual(false, orderLine.IsPhysical());
            Assert.AreEqual(false, orderLine.IsDiscount());
            Assert.AreEqual(false, orderLine.IsDigital());
            Assert.AreEqual(true, orderLine.IsShippingFee());
            Assert.AreEqual(false, orderLine.IsStoreCredit());
            Assert.AreEqual(false, orderLine.IsGiftCard());
            Assert.AreEqual(false, orderLine.IsSurcharge());

            orderLine.Type = OrderLineType.TYPE_STORE_CREDIT;
            Assert.AreEqual(false, orderLine.IsPhysical());
            Assert.AreEqual(false, orderLine.IsDiscount());
            Assert.AreEqual(false, orderLine.IsDigital());
            Assert.AreEqual(false, orderLine.IsShippingFee());
            Assert.AreEqual(true, orderLine.IsStoreCredit());
            Assert.AreEqual(false, orderLine.IsGiftCard());
            Assert.AreEqual(false, orderLine.IsSurcharge());

            orderLine.Type = OrderLineType.TYPE_GIFT_CARD;
            Assert.AreEqual(false, orderLine.IsPhysical());
            Assert.AreEqual(false, orderLine.IsDiscount());
            Assert.AreEqual(false, orderLine.IsDigital());
            Assert.AreEqual(false, orderLine.IsShippingFee());
            Assert.AreEqual(false, orderLine.IsStoreCredit());
            Assert.AreEqual(true, orderLine.IsGiftCard());
            Assert.AreEqual(false, orderLine.IsSurcharge());

            orderLine.Type = OrderLineType.TYPE_SURCHARGE;
            Assert.AreEqual(false, orderLine.IsPhysical());
            Assert.AreEqual(false, orderLine.IsDiscount());
            Assert.AreEqual(false, orderLine.IsDigital());
            Assert.AreEqual(false, orderLine.IsShippingFee());
            Assert.AreEqual(false, orderLine.IsStoreCredit());
            Assert.AreEqual(false, orderLine.IsGiftCard());
            Assert.AreEqual(true, orderLine.IsSurcharge());
        }
    }
}
