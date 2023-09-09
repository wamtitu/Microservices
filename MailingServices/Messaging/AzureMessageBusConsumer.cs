using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using MailingServices.Models;
using MailingServices.Services;
using Newtonsoft.Json;

namespace MailingServices.Messaging
{
    public class AzureMessageBusConsumer : IAzureMessageBusConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly string Connectionstring;
        private readonly string QueueName;
        private readonly ServiceBusProcessor _registrationProcessor;
        private readonly ServiceBusProcessor _orderEmails;
        private readonly SendEmailServices _emailService;
        private readonly EmailServices _saveToDb;
        public AzureMessageBusConsumer(IConfiguration configuration ,EmailServices service)
        {

            _configuration = configuration;
            Connectionstring= _configuration.GetSection("ServiceBus:ConnectionString").Get<string>();
            QueueName= _configuration.GetSection("QueuesandTopics:RegisterUser").Get<string>();


            var serviceBusClient = new ServiceBusClient(Connectionstring);
            _registrationProcessor = serviceBusClient.CreateProcessor(QueueName);
            _emailService = new SendEmailServices(_configuration);
            _saveToDb = service;

        }
         public async Task Start()
        {
            //start Processing
            _registrationProcessor.ProcessMessageAsync += OnRegistartion;
            _registrationProcessor.ProcessErrorAsync += ErrorHandler;
            await _registrationProcessor.StartProcessingAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }

        public async Task Stop()
        {
            await  _registrationProcessor.StopProcessingAsync();
           await _registrationProcessor.DisposeAsync();
        }

        private async Task OnRegistartion(ProcessMessageEventArgs arg)
        {
            var message= arg.Message;

            var body = Encoding.UTF8.GetString(message.Body);

            var userMessage= JsonConvert.DeserializeObject<UserMessage>(body);

            //TODO send An Email
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<img src=\"https://unsplash.com/photos/ip9R11FMbV8\" width=\"1000\" height=\"600\">");
                stringBuilder.Append("<h1> Hello " + userMessage.Name + "</h1>");
                stringBuilder.AppendLine("<br/>Welcome to The Blog ");

                stringBuilder.Append("<br/>");
                stringBuilder.Append('\n');
                stringBuilder.Append("<p> Start create posts and blog freely here</p>");
                var emailLogger = new RegEmail()
                {
                    Email = userMessage.Email,
                    Message = stringBuilder.ToString()

                };
                await _saveToDb.SaveData(emailLogger);
                await _emailService.SendEmail(userMessage, stringBuilder.ToString());
                //you can delete the message from the queue
                 await arg.CompleteMessageAsync(message);
            }catch (Exception ex) { }
        }

        
    }
}