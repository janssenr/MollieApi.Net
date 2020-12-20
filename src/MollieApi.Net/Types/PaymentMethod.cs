using System;

namespace MollieApi.Net.Types
{
    public class PaymentMethod
    {
        /// <summary>
        /// @link https://www.mollie.com/en/payments/applepay
        /// </summary>
        public const string APPLEPAY = "applepay";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/bancontact
        /// </summary>
        public const string BANCONTACT = "bancontact";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/bank-transfer
        /// </summary>
        public const string BANKTRANSFER = "banktransfer";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/belfius
        /// </summary>
        public const string BELFIUS = "belfius";

        /// <summary>
        /// @deprecated 2019-05-01
        /// </summary>
        [Obsolete]
        public const string BITCOIN = "bitcoin";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/credit-card
        /// </summary>
        public const string CREDITCARD = "creditcard";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/direct-debit
        /// </summary>
        public const string DIRECTDEBIT = "directdebit";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/eps
        /// </summary>
        public const string EPS = "eps";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/gift-cards
        /// </summary>
        public const string GIFTCARD = "giftcard";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/giropay
        /// </summary>
        public const string GIROPAY = "giropay";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/ideal
        /// </summary>
        public const string IDEAL = "ideal";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/ing-homepay
        /// </summary>
        public const string INGHOMEPAY = "inghomepay";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/kbc-cbc
        /// </summary>
        public const string KBC = "kbc";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/klarna-pay-later
        /// </summary>
        public const string KLARNA_PAY_LATER = "klarnapaylater";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/klarna-slice-it
        /// </summary>
        public const string KLARNA_SLICE_IT = "klarnasliceit";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/mybank
        /// </summary>
        public const string MYBANK = "mybank";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/paypal
        /// </summary>
        public const string PAYPAL = "paypal";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/paysafecard
        /// </summary>
        public const string PAYSAFECARD = "paysafecard";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/przelewy24
        /// </summary>
        public const string PRZELEWY24 = "przelewy24";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/gift-cards
        /// </summary>
        [Obsolete]
        public const string PODIUMCADEAUKAART = "podiumcadeaukaart";

        /// <summary>
        /// @link https://www.mollie.com/en/payments/sofort
        /// </summary>
        public const string SOFORT = "sofort";
    }
}
