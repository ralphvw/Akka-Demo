namespace AkkaDemo;

public class EmailNotification: IEmailNotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}