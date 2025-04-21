namespace InternshipTaskFiles;

public class Logger
{
    private static readonly Lock Lock = new();
    private static Logger? _instance;
    private const string LogDirectory = "Logs";

    private Logger()
    {
        Directory.CreateDirectory(LogDirectory);
    }
    
    public static Logger Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (Lock) _instance ??= new Logger();
            return _instance;
        }
    }
    
    public async Task Log(string methodName, bool isSuccess)
    {
        var logFilePath = Path.Combine(LogDirectory, $"Logs_{DateTime.Now:yyyy-MM-dd}.txt");
        var logEntry = $"{methodName},{DateTime.Now:yyyy-MM-dd HH:mm:ss},{(isSuccess ? "success" : "failure")}";
            
        await File.AppendAllTextAsync(logFilePath, logEntry + Environment.NewLine);
    }
}