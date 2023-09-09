using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailingServices.Messaging;

namespace MailingServices.Extensions
{
    public static class AzureServicesStarter
    {
        public static IAzureMessageBusConsumer ServiceBusConsumerInstance {get;set;}
        public static  IApplicationBuilder useAzure(this IApplicationBuilder app){
            ServiceBusConsumerInstance = app.ApplicationServices.GetService<IAzureMessageBusConsumer>();
            var HostLifetime= app.ApplicationServices.GetService<IHostApplicationLifetime>();
            HostLifetime.ApplicationStarted.Register(OnStart);
            HostLifetime.ApplicationStopping.Register(OnStop);

            return app;


        }

        private static void OnStop()
        {
            //Stop our Email Processor
           ServiceBusConsumerInstance.Stop();
        }

        private static void OnStart()
        {
             //start our Email Processor
            ServiceBusConsumerInstance.Start();
        }
    }
}