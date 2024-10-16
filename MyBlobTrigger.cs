using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace isolated_function;
/// Start Azurite
///    azurite --silent --location c:\azurite --debug c:\azurite\debug.log
/// 





public class MyBlobTrigger
{
    private readonly ILogger<MyBlobTrigger> _logger;

    public MyBlobTrigger(ILogger<MyBlobTrigger> logger)
    {
        _logger = logger;
    }

    [Function(nameof(MyBlobTrigger))]
    public async Task Run([BlobTrigger("sample-container/{name}", Connection = "BLOB_STORAGE_CONNECTION_STRING")] Stream stream, string name)
    {
        throw new Exception("Something went wrong");
        // using var blobStreamReader = new StreamReader(stream);
        // var content = await blobStreamReader.ReadToEndAsync();
        // _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
    }
}