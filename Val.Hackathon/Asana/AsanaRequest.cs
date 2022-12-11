using System.Text.Json.Serialization;

namespace Val.Hackathon.Asana
{
    public class AsanaRequest<T> where T : class
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        public AsanaRequest(T data)
        {
            Data = data;
        }
    }
}
