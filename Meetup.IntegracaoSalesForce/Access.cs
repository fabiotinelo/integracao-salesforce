using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Meetup.IntegracaoSalesForce
{
    public class Access
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("instance_url")]
        public string InstanceURL { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("issued_at")]
        public string IssuedAt { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        //	public IVersion VersionAPI { get; set; }

       // public string InstanceURLVersionAPI { get => string.Concat(InstanceURL, ""); }
    }
}
