using Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<ServiceFact>(); 

var host = builder.Build();


var catFactService = host.Services.GetRequiredService<ServiceFact>();
await catFactService.AddNewFactAsync();