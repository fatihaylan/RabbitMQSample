// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Consumer;
using RabbitMQ.Services;

Console.WriteLine("Consumer running!");

var serviceProvider = ServiceProviderHelper.GetServiceProvider();
var consumerManager = serviceProvider.GetRequiredService<IConsumerManager>();

Console.WriteLine($"Consuming started! {DateTime.Now:T}");
consumerManager.Consume();

Console.ReadKey();

Console.WriteLine($"Consuming finished! {DateTime.Now:T}");