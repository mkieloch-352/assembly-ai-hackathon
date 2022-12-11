using System.Text.Json.Serialization;

namespace Val.Hackathon.Asana
{
    public class AsanaObject<T> where T : class
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }

        public AsanaObject(T data)
        {
            Data = data;
        }
    }
}
