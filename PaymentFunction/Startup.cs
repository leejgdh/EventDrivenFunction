using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SlackSDK.Client;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(PaymentFunction.Startup))]
namespace PaymentFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services.AddHttpClient("Slack");

            builder.Services.AddSingleton<SlackClient>();

            //builder.Services.AddDbContext<CustomOrderContext>(e =>
            //{
            //    e.UseCosmos(
            //        configuration.GetSection("Test")["AccountEndPoint"],
            //        configuration.GetSection("Test")["AccountKey"],
            //        configuration.GetSection("Test")["DatabaseName"]
            //    );
            //});

            //builder.Services.AddTransient<ICustomOrderService, CustomOrderService>();
        }
    }
}