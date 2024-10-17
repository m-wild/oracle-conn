using System.CommandLine;
using Oracle.ManagedDataAccess.Client;

var cs = new Option<string>("--connection-string", "Oracle DB connection string");
var cmd = new RootCommand("Test oracle DB connectivity");
cmd.AddOption(cs);

cmd.SetHandler(async (context) => {

    var connectionString = context.ParseResult.GetValueForOption(cs);

    using var conn = new OracleConnection(connectionString);
    await conn.OpenAsync(context.GetCancellationToken());

    
    Console.WriteLine($"ConnectionID     = {conn.ConnectionId}");
    Console.WriteLine($"State            = {conn.State}");
    Console.WriteLine($"ConnectionString = {conn.ConnectionString}");
    Console.WriteLine($"DatabaseName     = {conn.DatabaseName}");
    Console.WriteLine($"HostName         = {conn.HostName}");
    Console.WriteLine($"InstanceName     = {conn.InstanceName}");
    Console.WriteLine($"ServerVersion    = {conn.ServerVersion}");
    Console.WriteLine($"ServiceName      = {conn.ServiceName}");
});

await cmd.InvokeAsync(args);