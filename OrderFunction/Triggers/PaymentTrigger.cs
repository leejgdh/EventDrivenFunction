using System;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace OrderFunction.Triggers
{
    public class PaymentTrigger
    {
        private readonly ILogger<PaymentTrigger> _logger;

        public PaymentTrigger(ILogger<PaymentTrigger> log)
        {
            _logger = log;
        }

        /// <summary>
        /// 이런식으로도 구현 가능
        /// </summary>
        /// <param name="message"></param>
        //[FunctionName("ServiceBusSubscription")]
        //public async Task ReceiveSubscription(
        //   [ServiceBusTrigger("topic", "subscription", Connection = "ServiceBus")]
        //    Message messageContext,
        //   MessageReceiver messageReceiver,
        //   string lockToken,
        //   ILogger logger
        //   )
        //{
        //    string message = Encoding.UTF8.GetString(messageContext.Body);

        //    logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

        //    switch (messageContext.Label)
        //    {
        //        case nameof(PaymentCompleted): await PaymentCompleted(message, logger); break;
        //        case nameof(PaymentCanceled): await PaymentCanceled(message, logger); break;
        //        case nameof(InventoryRelease): await InventoryRelease(message, logger); break;
        //        default:
        //            throw new ArgumentException($"label is not defined {messageContext.Label}");
        //    }
        //}

        [FunctionName("PaymentCreate")]
        public void PaymentCreate([ServiceBusTrigger("payment", "PaymentCreate", Connection = "ServiceBus")] string message)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");

        }
    }
}
