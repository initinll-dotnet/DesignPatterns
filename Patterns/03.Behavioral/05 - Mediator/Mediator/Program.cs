using Mediator;

Console.Title = "Mediator";

// Team members
var sven = new Lawyer("Sven");
var kenneth = new Lawyer("Kenneth");
var ann = new AccountManager("Ann");
var john = new AccountManager("John");
var kylie = new AccountManager("Kylie");

// Chat Room Mediator
TeamChatRoomMediator teamChatroomMediator = new();
teamChatroomMediator.Register(sven);
teamChatroomMediator.Register(kenneth);
teamChatroomMediator.Register(ann);
teamChatroomMediator.Register(john);
teamChatroomMediator.Register(kylie);

// Interaction in chat room via mediator
ann.Send("Hi everyone, can someone have a look at file ABC123?  I need a compliance check.");
sven.Send("On it!");
sven.Send("Ann", "Could you join me in a Teams call?");
sven.Send("Ann", "All good :)");
ann.SendTo<AccountManager>("The file was approved!");

Console.ReadKey();