using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace isolated_function;

/// Start Azurite
///    azurite --silent --location c:\azurite --debug c:\azurite\debug.log
/// 

public class MyBlobPoisonTrigger
{
    private readonly ILogger<MyBlobTrigger> _logger;

    public MyBlobPoisonTrigger(ILogger<MyBlobTrigger> logger)
    {
        _logger = logger;
    }

    [Function(nameof(MyBlobPoisonTrigger))]
    public async Task Run([BlobTrigger("webjobs-blobtrigger-poison", Connection = "")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
    }
}