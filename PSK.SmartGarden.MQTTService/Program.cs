using System;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Server;

namespace PSK.SmartGarden.MQTTService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var mqttServer = new MqttFactory().CreateMqttServer();
            
            var optionsBuilder = new MqttServerOptionsBuilder()
                .WithConnectionBacklog(100)
                .WithDefaultEndpointPort(1884);

            mqttServer.UseClientConnectedHandler(x =>
            {
                Console.WriteLine($"Client ({x.ClientId}) has just connected to the server.");
            });
            
            mqttServer.UseClientDisconnectedHandler(x =>
            {
                Console.WriteLine($"Client ({x.ClientId}) has just disconnected from the server.");
            });

            await mqttServer.StartAsync(optionsBuilder.Build());
            
            Console.WriteLine($"[{DateTime.Now}] MQTT server has been started! Listening on port 1884.");
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
            
            await mqttServer.StopAsync();
        }
    }
}