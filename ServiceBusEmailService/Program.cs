using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using ServiceBusEmailService.ViewModel;
using System;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ServiceBusEmailService
{
    class Program
    {
        //Azure Service Bus Connection String
        static string connectionString = "Endpoint=sb://auxiliumnayatel.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ObEAb3tGd5xJ/ijTi2u5n5ghQWWDlb5EqfYJKsmzbqo=";
        //Queue Name i n which message is received and send.
        static string queueName = "auxiliumnayatel";
        // the client that owns the connection and can be used to create senders and receivers
        static ServiceBusClient client;
        // the processor that reads and processes messages from the queue
        static ServiceBusProcessor processor;
        


        static async Task Main(string[] args)
        {
            client = new ServiceBusClient(connectionString);
            processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());
            try
            {
                processor.ProcessMessageAsync += QueueReceiver.MessageReceiver;
                processor.ProcessErrorAsync += QueueReceiver.QueueErrorHandler;
                //start processing messages
                await processor.StartProcessingAsync();
                Console.ReadKey();
                //stop processing after queue is empty
                await processor.StopProcessingAsync();
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    } 
}
