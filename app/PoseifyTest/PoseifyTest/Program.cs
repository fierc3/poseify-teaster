using PoseifyTest;

string hostName = "rabbitmq"; 
string queueName = "video2pose";
string message = "Ready";
string messageType = "videopose3d";

Console.WriteLine("Press 'x' to send a message. Press 'q' to quit.");

var sender = new RabbitMQSender();

while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    if (key == ConsoleKey.X)
    {
        string guid = Guid.NewGuid().ToString();
        sender.SendMessage(hostName, queueName, message, guid, messageType);
    }
    else if (key == ConsoleKey.Q)
    {
        break;
    }
}