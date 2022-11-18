using Newtonsoft.Json;

namespace SharedProject.Models
{
    public interface IServiceBusEventBase
    {
        [JsonIgnore]
        public string Topic { get; }

        [JsonIgnore]
        public string Subject { get; }
    }
}
