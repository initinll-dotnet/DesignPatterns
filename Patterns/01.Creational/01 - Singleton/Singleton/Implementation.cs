namespace Singleton;

/// <summary>
/// Singleton
/// </summary>
public class Logger
{
    // Lazy<T>
    // Lazy<T> is a thread-safe class that allows you to create a single instance of a class in a multithreaded environment.
    private static readonly Lazy<Logger> _lazyLogger
        = new(() => new Logger());

    // not thread safe
    // private static Logger? _instance;

    /// <summary>
    /// Instance
    /// </summary>
    public static Logger Instance
    {
        get
        {
            // Thread safe and lazy initialization
            return _lazyLogger.Value;

            // not thread safe
            //if (_instance == null)
            //{
            //    _instance = new Logger();
            //}
            //return _instance;
        }
    }

    protected Logger()
    {
    }

    /// <summary>
    /// SingletonOperation
    /// </summary> 
    public void Log(string message)
    {
        Console.WriteLine($"Message to log: {message}");
    }
}