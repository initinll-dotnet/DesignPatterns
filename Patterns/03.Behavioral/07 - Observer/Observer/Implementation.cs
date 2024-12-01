namespace Observer;

public class TicketChange
{
    public int Amount { get; private set; }
    public int ArtistId { get; private set; }

    public TicketChange(int artistId, int amount)
    {
        Amount = amount;
        ArtistId = artistId;
    }
}

/// <summary>
/// Subject
/// </summary>
public abstract class TicketChangeNotifier
{
    private List<ITicketChangeListener> _observers = [];

    public void AddObserver(ITicketChangeListener observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(ITicketChangeListener observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(TicketChange ticketChange)
    {
        foreach (var observer in _observers)
        {
            observer.ReceiveTicketChangeNotification(ticketChange);
        }
    }
}

/// <summary>
/// Observer
/// </summary>
public interface ITicketChangeListener
{
    void ReceiveTicketChangeNotification(TicketChange ticketChange);
}

/// <summary>
/// ConcreteSubject
/// </summary>
public class OrderServiceNotifier : TicketChangeNotifier
{
    public void CompleteTicketSale(int artistId, int amount)
    {
        // change local datastore.  Datastore omitted in demo implementation.
        Console.WriteLine($"{nameof(OrderServiceNotifier)} is changing its state.");

        // notify observers 
        Console.WriteLine($"{nameof(OrderServiceNotifier)} is notifying observers...");

        base.Notify(new TicketChange(artistId, amount));
    }
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class TicketResellerServiceListener : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        // update local datastore (datastore omitted in demo implementation)
        Console.WriteLine($"{nameof(TicketResellerServiceListener)} notified " +
            $"of ticket change: artist {ticketChange.ArtistId}, amount " +
            $"{ticketChange.Amount}");
    }
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class TicketStockServiceListener : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        // update local datastore (datastore omitted in demo implementation)
        Console.WriteLine($"{nameof(TicketStockServiceListener)} notified " +
            $"of ticket change: artist {ticketChange.ArtistId}, amount " +
            $"{ticketChange.Amount}");
    }
}
