using System.Net.Sockets;
using Aspire.Hosting;
var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var rabbitMqPassword = builder.AddParameter("RabbitMqPassword", true);
var rabbitMq = builder.AddRabbitMQ("RabbitMq", password: rabbitMqPassword)
    .WithDataVolume()
    .WithVolume("/etc/rabbitmq")
    .WithManagementPlugin();

var sqlServerPassword = builder.AddParameter("SqlServerInstancePassword", true);
var sqlServer = builder.AddSqlServer("SqlServerInstance", sqlServerPassword)
    .WithEndpoint(port: 1433, targetPort:1433, name:"sql", protocol:ProtocolType.Tcp)
    .WithDataVolume();

var database = sqlServer.AddDatabase("ThundersTechTestDb", "ThundersTechTest");

var api = builder.AddProject<Projects.Thunders_TechTest_ApiService>("api")
    .WithReference(rabbitMq)
    .WithReference(database)
    .WaitFor(rabbitMq)
    .WaitFor(database);

builder.Build().Run();