using Newtonsoft.Json;
using System;

namespace SharedProject.Models.DTO.ServiceBusMessage.Payment
{
    public class RequestCreatePaymentMsg : IServiceBusEventBase
    {
        [JsonIgnore]
        public string Topic => "Payment";

        [JsonIgnore]
        public string Subject => "PaymentCreate";

        [JsonRequired]
        public Guid? OrderId { get; set; }

        [JsonRequired]
        public Guid? PaymentId { get; set; }

        
    }
}
