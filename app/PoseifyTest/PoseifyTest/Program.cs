using PoseifyTest;

string hostName = "rabbitmq"; 
string queueName = "video2pose";
string message = "Ready";
string messageType = "videopose3d";
string user = "06b51e62-74b7-4493-8f97-376ab61315c3";

Console.WriteLine("Press 'x' to send a message. Press 'q' to quit.");

var sender = new RabbitMQSender();

while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    if (key == ConsoleKey.X)
    {
        //string guid = Guid.NewGuid().ToString();
        string guid = "Running";
        sender.SendMessage(hostName, queueName, message, guid, messageType, user);
    }
    else if (key == ConsoleKey.Q)
    {
        break;
    }
}