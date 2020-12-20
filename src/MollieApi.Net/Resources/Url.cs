using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Url
    {
        [DataMember(Name = "href", EmitDefaultValue = false)]
        public Uri Href { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = true)]
        public string Type { get; set; }

        public Url() { }

        public Url(Uri href, string type)
        {
            Href = href;
            Type = type;
        }

        public Url(string href, string type) : this(new Uri(href), type) { }

        public override bool Equals(object obj)
        {
            if (!(obj is Url url)) return false;
            if (!Equals(url.Href, Href)) return false;
            if (!Equals(url.Type, Type)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -1399565275;
            hashCode = hashCode * -1521134295 + EqualityComparer<Uri>.Default.GetHashCode(Href);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            return hashCode;
        }

        public override string ToString()
        {
            return Href.ToString();
        }
    }
}
