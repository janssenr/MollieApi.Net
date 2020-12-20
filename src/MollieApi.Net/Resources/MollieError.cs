using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class MollieError
    {
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public int Status { get; set; }

        [DataMember(Name = "title", EmitDefaultValue = false, IsRequired = false)]
        public string Title { get; set; }

        [DataMember(Name = "detail", EmitDefaultValue = false, IsRequired = false)]
        public string Detail { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { private get; set; }

        public string GetDocumentationUrl()
        {
            if (Links.Documentation == null)
                return null;

            return Links.Documentation.Href.ToString();
        }

        public string GetDashboardUrl()
        {
            if (Links.Dashboard == null)
                return null;

            return Links.Dashboard.Href.ToString();
        }
    }
}
