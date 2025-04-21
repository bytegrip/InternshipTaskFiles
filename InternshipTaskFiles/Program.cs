using InternshipTaskFiles;

await ProcessNumberAsync(5);
await ProcessNumberAsync(10);
await ProcessNumberAsync(15);

try
{
    await ProcessNumberAsync(0);
}
catch (Exception)
{
    Console.Write("");
}
            
try
{
    await ProcessNumberAsync(13); 
}
catch (Exception)
{
    Console.Write("");
}

return;

static async Task ProcessNumberAsync(int number)
{
    var success = false;
            
    try
    {
        Console.WriteLine($"Processing number: {number}");
                
        switch (number)
        {
            case 0:
                throw new ArgumentException("Cannot process zero");
            case 13:
                throw new Exception("Unlucky number detected");
        }

        await Task.Delay(100); 
        success = true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing number {number}: {ex.Message}");
        throw;
    }
    finally
    {
        await Logger.Instance.Log(nameof(ProcessNumberAsync), success);
    }
}