using Akka.Actor;

namespace AkkaDemo;

public class NotificationActor: UntypedActor
{
    private readonly IEmailNotification _emailNotification;

    public NotificationActor(IEmailNotification emailNotification)
    {
        _emailNotification = emailNotification;
    }
    protected override void OnReceive(object message)
    {
        Console.WriteLine($"Message received: {message}");
        _emailNotification.Send(message?.ToString());
    }

    protected override void PreStart()
    {
        Console.WriteLine("Actor started");
    }

    protected override void PostStop()
    {
        Console.WriteLine("Actor stopped");
    }
}