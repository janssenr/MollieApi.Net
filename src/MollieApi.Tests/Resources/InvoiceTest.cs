using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class InvoiceTest
    {
        public void TestInvoiceStatuses()
        {
            var invoice = new Invoice();

            invoice.Status = InvoiceStatus.STATUS_PAID;
            Assert.AreEqual(true, invoice.IsPaid());
            Assert.AreEqual(false, invoice.IsOpen());
            Assert.AreEqual(false, invoice.IsOverdue());

            invoice.Status = InvoiceStatus.STATUS_OPEN;
            Assert.AreEqual(false, invoice.IsPaid());
            Assert.AreEqual(true, invoice.IsOpen());
            Assert.AreEqual(false, invoice.IsOverdue());

            invoice.Status = InvoiceStatus.STATUS_OVERDUE;
            Assert.AreEqual(false, invoice.IsPaid());
            Assert.AreEqual(false, invoice.IsOpen());
            Assert.AreEqual(true, invoice.IsOverdue());
        }
    }
}
