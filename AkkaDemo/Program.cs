using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Extensions.DependencyInjection;
using AkkaDemo;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IEmailNotification, EmailNotification>();
serviceCollection.AddSingleton<NotificationActor>();
var serviceProvider = serviceCollection.BuildServiceProvider();

var actorSystem = ActorSystem.Create("test-actor-system");
actorSystem.UseServiceProvider(serviceProvider);

var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());
actor.Tell("Hello There!");
actorSystem.Stop(actor);
