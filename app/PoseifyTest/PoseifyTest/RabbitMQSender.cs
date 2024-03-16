using System;
using RabbitMQ.Client;
using System.Text;
using System.Collections.Generic;

namespace PoseifyTest
{
    public class RabbitMQSender
    {
        public void SendMessage(string hostName, string queueName, string message, string guid, string messageType, string user)
        {
            var factory = new ConnectionFactory() { HostName = hostName, UserName = "user", Password = "password" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.Headers = new Dictionary<string, object>
            {
                { "GUID", guid },
                { "Type", messageType },
                { "User", user }
            };

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }
    }
}