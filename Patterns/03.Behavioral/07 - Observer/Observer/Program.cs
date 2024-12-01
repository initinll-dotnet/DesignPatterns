using Observer;

Console.Title = "Observer";

TicketStockServiceListener ticketStockServiceListener = new();
TicketResellerServiceListener ticketResellerServiceListener = new();
OrderServiceNotifier orderServiceNotifier = new();

// add two observers
orderServiceNotifier.AddObserver(ticketStockServiceListener);
orderServiceNotifier.AddObserver(ticketResellerServiceListener);

// notify
orderServiceNotifier.CompleteTicketSale(1, 2);

Console.WriteLine();

// remove one observer
orderServiceNotifier.RemoveObserver(ticketResellerServiceListener);

// notify
orderServiceNotifier.CompleteTicketSale(2, 4);

Console.ReadKey();