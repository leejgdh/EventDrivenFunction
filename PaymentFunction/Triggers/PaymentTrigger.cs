using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using PaymentFunction.Models.DTO;
using SharedProject.Helper;
using SharedProject.Models.DTO.ServiceBusMessage.Payment;
using SlackSDK.Client;
using SlackSDK.Models.DTO;
using SlackSDK.Models.Enums;

namespace PaymentFunction.Triggers
{
    public class PaymentTrigger
    {
        private ServiceBusClient _serviceBusClient;
        private SlackClient _slackClient;

        private Uri _webHookUrl = new Uri("https://hooks.slack.com/services/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");

        public PaymentTrigger(
            IConfiguration config,
            SlackClient slackClient
            )
        {
            _serviceBusClient = new ServiceBusClient(config.GetConnectionString("ServiceBus"));
            _slackClient = slackClient;
        }

        [FunctionName("PaymentCreate")]
        public async Task<IActionResult> CreatePayment(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "Payment")] RequestCreatePayment req,
            ILogger log)
        {

            RequestCreatePaymentMsg sb_msg = new RequestCreatePaymentMsg()
            {
                OrderId = req.OrderId
            };

            //db 처리

            sb_msg.PaymentId = Guid.NewGuid();

            await _serviceBusClient.SendMessageAsync(sb_msg);

            log.LogInformation($"결제 아이디 {sb_msg.PaymentId}번 결제 완료 처리");

            SlackMessage message = new SlackMessage(EAttachmentColor.Success, "title", "value");

            var message_res = await _slackClient.SendMessageAsync(_webHookUrl,message);

            return new NoContentResult();
        }
    }
}
