using Decorator;

Console.Title = "Decorator";

// instantiate mail services
CloudMailService cloudMailService = new();
cloudMailService.SendMail("Hi there.");

OnPremiseMailService onPremiseMailService = new();
onPremiseMailService.SendMail("Hi there.");

// add behavior
StatisticsDecorator statisticsDecorator = new(mailService: cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper.");

// add behavior
MessageDatabaseDecorator messageDatabaseDecorator = new(mailService: onPremiseMailService);

messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 1.");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 2.");

foreach (var message in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine($"Stored message: \"{message}\"");
}

Console.ReadKey();