using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class PaymentTest
    {
        [TestMethod]
        public void TestPaymentStatuses()
        {
            var payment = new Payment();

            payment.Status = PaymentStatus.STATUS_PENDING;
            Assert.AreEqual(true, payment.IsPending());
            Assert.AreEqual(false, payment.IsAuthorized());
            Assert.AreEqual(false, payment.IsFailed());
            Assert.AreEqual(false, payment.IsOpen());
            Assert.AreEqual(false, payment.IsCancelled());
            Assert.AreEqual(false, payment.IsPaid());
            Assert.AreEqual(false, payment.IsExpired());

            payment.Status = PaymentStatus.STATUS_AUTHORIZED;
            Assert.AreEqual(false, payment.IsPending());
            Assert.AreEqual(true, payment.IsAuthorized());
            Assert.AreEqual(false, payment.IsFailed());
            Assert.AreEqual(false, payment.IsOpen());
            Assert.AreEqual(false, payment.IsCancelled());
            Assert.AreEqual(false, payment.IsPaid());
            Assert.AreEqual(false, payment.IsExpired());

            payment.Status = PaymentStatus.STATUS_FAILED;
            Assert.AreEqual(false, payment.IsPending());
            Assert.AreEqual(false, payment.IsAuthorized());
            Assert.AreEqual(true, payment.IsFailed());
            Assert.AreEqual(false, payment.IsOpen());
            Assert.AreEqual(false, payment.IsCancelled());
            Assert.AreEqual(false, payment.IsPaid());
            Assert.AreEqual(false, payment.IsExpired());

            payment.Status = PaymentStatus.STATUS_OPEN;
            Assert.AreEqual(false, payment.IsPending());
            Assert.AreEqual(false, payment.IsAuthorized());
            Assert.AreEqual(false, payment.IsFailed());
            Assert.AreEqual(true, payment.IsOpen());
            Assert.AreEqual(false, payment.IsCancelled());
            Assert.AreEqual(false, payment.IsPaid());
            Assert.AreEqual(false, payment.IsExpired());

            payment.Status = PaymentStatus.STATUS_CANCELED;
            Assert.AreEqual(false, payment.IsPending());
            Assert.AreEqual(false, payment.IsAuthorized());
            Assert.AreEqual(false, payment.IsFailed());
            Assert.AreEqual(false, payment.IsOpen());
            Assert.AreEqual(true, payment.IsCancelled());
            Assert.AreEqual(false, payment.IsPaid());
            Assert.AreEqual(false, payment.IsExpired());

            payment.Status = PaymentStatus.STATUS_EXPIRED;
            Assert.AreEqual(false, payment.IsPending());
            Assert.AreEqual(false, payment.IsAuthorized());
            Assert.AreEqual(false, payment.IsFailed());
            Assert.AreEqual(false, payment.IsOpen());
            Assert.AreEqual(false, payment.IsCancelled());
            Assert.AreEqual(false, payment.IsPaid());
            Assert.AreEqual(true, payment.IsExpired());
        }

        [TestMethod]
        public void TestIsPaidReturnsTrueWhenPaidDatetimeIsSet()
        {
            var payment = new Payment();

            payment.PaidAt = new DateTime(2016, 10, 24);
            Assert.IsTrue(payment.IsPaid());
        }

        [TestMethod]
        public void TestHasRefundsReturnsTrueWhenPaymentHasRefunds()
        {
            var payment = new Payment();

            payment.Links = new Links
            {
                Refunds = new Url { Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/refunds"), Type = "application/hal+json" }
            };
            Assert.IsTrue(payment.HasRefunds());
        }

        [TestMethod]
        public void TestHasRefundsReturnsFalseWhenPaymentHasNoRefunds()
        {
            var payment = new Payment();

            payment.Links = new Links();
            Assert.IsFalse(payment.HasRefunds());
        }

        [TestMethod]
        public void TestHasChargebacksReturnsTrueWhenPaymentHasChargebacks()
        {
            var payment = new Payment();

            payment.Links = new Links
            {
                Chargebacks = new Url { Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/chargebacks"), Type = "application/hal+json" }
            };
            Assert.IsTrue(payment.HasChargebacks());
        }

        [TestMethod]
        public void TestHasChargebacksReturnsFalseWhenPaymentHasNoChargebacks()
        {
            var payment = new Payment();

            payment.Links = new Links();
            Assert.IsFalse(payment.HasChargebacks());
        }

        [TestMethod]
        public void TestHasRecurringTypeReturnsTrueWhenRecurringTypeIsFirst()
        {
            var payment = new Payment();

            payment.SequenceType = SequenceType.SEQUENCETYPE_FIRST;
            Assert.IsFalse(payment.HasSequenceTypeRecurring());
            Assert.IsTrue(payment.HasSequenceTypeFirst());
        }

        [TestMethod]
        public void TestHasRecurringTypeReturnsTrueWhenRecurringTypeIsRecurring()
        {
            var payment = new Payment();

            payment.SequenceType = SequenceType.SEQUENCETYPE_RECURRING;
            Assert.IsTrue(payment.HasSequenceTypeRecurring());
            Assert.IsFalse(payment.HasSequenceTypeFirst());
        }

        [TestMethod]
        public void TestHasRecurringTypeReturnsFalseWhenRecurringTypeIsNone()
        {
            var payment = new Payment();

            payment.SequenceType = SequenceType.SEQUENCETYPE_ONEOFF;
            Assert.IsFalse(payment.HasSequenceTypeRecurring());
            Assert.IsFalse(payment.HasSequenceTypeFirst());
        }

        [TestMethod]
        public void TestGetCheckoutUrlReturnsPaymentUrlFromLinksObject()
        {
            var payment = new Payment();

            payment.Links = new Links
            {
                Checkout = new Url { Href = new Uri("https://example.com/") }
            };

            Assert.AreEqual("https://example.com/", payment.GetCheckoutUrl());
        }

        [TestMethod]
        public void TestCanBeRefundedReturnsTrueWhenAmountRemainingIsSet()
        {
            var payment = new Payment();

            payment.AmountRemaining = new Amount { Value = "15", Currency = "EUR" };
            Assert.IsTrue(payment.CanBeRefunded());
            Assert.IsTrue(payment.CanBePartiallyRefunded());
        }

        [TestMethod]
        public void TestCanBeRefundedReturnsFalseWhenAmountRemainingIsNull()
        {
            var payment = new Payment();

            payment.AmountRemaining = null;
            Assert.IsFalse(payment.CanBeRefunded());
            Assert.IsFalse(payment.CanBePartiallyRefunded());
        }

        [TestMethod]
        public void TestGetAmountRefundedReturnsAmountRefundedAsFloat()
        {
            var payment = new Payment();

            payment.AmountRefunded = new Amount { Value = "22.0", Currency = "EUR" };
            Assert.AreEqual(22.0, payment.GetAmountRefunded());
        }

        [TestMethod]
        public void TestGetAmountRefundedReturns0WhenAmountRefundedIsSetToNull()
        {
            var payment = new Payment();

            payment.AmountRefunded = null;
            Assert.AreEqual(0.0, payment.GetAmountRefunded());
        }

        [TestMethod]
        public void TestGetAmountRemainingReturnsAmountRemainingAsFloat()
        {
            var payment = new Payment();

            payment.AmountRemaining = new Amount { Value = "22.0", Currency = "EUR" };
            Assert.AreEqual(22.0, payment.GetAmountRemaining());
        }

        [TestMethod]
        public void TestGetAmountRemainingReturns0WhenAmountRemainingIsSetToNull()
        {
            var payment = new Payment();

            payment.AmountRemaining = null;
            Assert.AreEqual(0.0, payment.GetAmountRemaining());
        }

        [TestMethod]
        public void TestGetSettlementAmountReturns0WhenSettlementAmountIsSetToNull()
        {
            var payment = new Payment();

            payment.SettlementAmount = null;
            Assert.AreEqual(0.0, payment.GetSettlementAmount());
        }

        [TestMethod]
        public void TestGetSettlementAmountReturnsSettlementAmountAsFloat()
        {
            var payment = new Payment();

            payment.SettlementAmount = new Amount { Value = "22.0", Currency = "EUR" };
            Assert.AreEqual(22.0, payment.GetSettlementAmount());
        }
    }
}
