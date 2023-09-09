using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailingServices.Messaging
{
    public interface IAzureMessageBusConsumer
    {
        Task Start();


        Task Stop();
    }
}