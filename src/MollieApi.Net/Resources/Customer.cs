using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Customer : BaseResource
    {
        /// <summary>
        /// Either "live" or "test". Indicates this being a test or a live (verified) customer.
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false, IsRequired = false)]
        public string Email { get; set; }

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

        [DataMember(Name = "metadata", EmitDefaultValue = false, IsRequired = false)]
        public string Metadata { get; set; }

        [DataMember(Name = "recentlyUsedMethods", EmitDefaultValue = false, IsRequired = false)]
        public string[] RecentlyUsedMethods { get; set; }

        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }
    }
}
