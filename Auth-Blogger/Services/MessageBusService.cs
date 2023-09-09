using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth_Blogger.Services.IServices;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace Auth_Blogger.Services
{
    public class MessageBusService:IMessageBus
    {
        public string ConnectionString = "Endpoint=sb://jituservices.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NFHrBc3qzkH6Syh9++naKAVc9sHnpzaTv+ASbDSjiwo=";
        public async Task PublishMessage(object message, string queue_topic_name){
            var servicebus = new ServiceBusClient(this.ConnectionString);
            var sender = servicebus.CreateSender(queue_topic_name);
            var jsonMessage=JsonConvert.SerializeObject(message);

            var myMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {

                //Give a unique iDentifier to all messages
                CorrelationId = Guid.NewGuid().ToString(),
            };


            //send Message
            await sender.SendMessageAsync(myMessage);

            await servicebus.DisposeAsync();
        }
    }
}