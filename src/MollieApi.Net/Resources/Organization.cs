using System.Globalization;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Organization : BaseResource
    {
        /// <summary>
        /// The name of the organization.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }

        /// <summary>
        /// The email address of the organization.
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false, IsRequired = false)]
        public string Email { get; set; }

        /// <summary>
        /// The preferred locale of the merchant which has been set in Mollie Dashboard.
        /// </summary>
        [DataMember(Name = "locale", EmitDefaultValue = false, IsRequired = false)]
        private string _locale;

        public CultureInfo Locale
        {
            get
            {
                return _locale != null ? new CultureInfo(_locale) : null;
            }
            set
            {
                _locale = value != null ? value.Name.Replace("-", "_") : null;
            }
        }

        /// <summary>
        /// The address of the organization.
        /// </summary>
        [DataMember(Name = "address", EmitDefaultValue = false, IsRequired = false)]
        public Address Address { get; set; }

        /// <summary>
        /// The registration number of the organization at the (local) chamber of commerce.
        /// </summary>
        [DataMember(Name = "registrationNumber", EmitDefaultValue = false, IsRequired = false)]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// The VAT number of the organization, if based in the European Union. The VAT number has been checked with the VIES by Mollie.
        /// </summary>
        [DataMember(Name = "vatNumber", EmitDefaultValue = false, IsRequired = false)]
        public string VatNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }
    }
}
