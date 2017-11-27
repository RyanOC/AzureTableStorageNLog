using System;
using Common.Logging;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Configuration;

namespace AzureTableStorageNLog
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            // -- nuget packages needed:
            // --------------------------
            // add common logging nlog41 (common.logging, common.logging.core, microsoft.csharp, and nlog get installed)
            // add AzureTableStorageNLogTarget

            // -- make sure all the nuget packages are up to date
            //-----------------------------------------------------------
            // windows azure storage ( needs to be 8.6.0)
            // microsoft azure key vault (needs to be 2.0.4)
            // microsoft azure configuration manager (needs to be 3.2.3) 

            // add app.config values

            LogTraceMessage();
            LogDebugMessage();
            LogInfoMessage();
            LogWarningMessage();
            LogErrorMessage();
            LogFatalErrorMessage();

            //DeleteTable();
        }


        private static void LogTraceMessage()
        {
            Log.Trace("This is a trace");
        }

        private static void LogDebugMessage()
        {
            Log.Debug("This is a debug message");
        }

        private static void LogInfoMessage()
        {
            Log.Info("This is an info message");
        }

        private static void LogWarningMessage()
        {
            Log.Warn("This is a warning");
        }

        private static void LogErrorMessage()
        {
            Log.Error("This is an error");
        }

        private static void LogFatalErrorMessage()
        {
            Log.Fatal("This is a fatal error");
        }

        private static void DeleteTable()
        {
            // https://docs.microsoft.com/en-us/azure/cosmos-db/table-storage-how-to-use-dotnet

            // Retrieve the storage account from the connection string.
            var connection = ConfigurationManager.ConnectionStrings["AzureTableStorage"].ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connection);
            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("AzureTableStorage"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("AzureTableStorageNLog");

            // Delete the table it if exists.
            table.DeleteIfExists();
        }
    }
}