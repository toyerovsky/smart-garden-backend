using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
using PSK.SmartGarden.Application;
using PSK.SmartGarden.Data.Repository;
using PSK.SmartGarden.Dto.Measurement;

namespace PSK.SmartGarden
{
    public class MqttMeasurementInsertionHandler
    {
        private readonly IMeasurementCommandService _measurementCommandService;

        public MqttMeasurementInsertionHandler(IMeasurementCommandService measurementCommandService)
        {
            _measurementCommandService = measurementCommandService;
        }

        public async Task Start()
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithClientId("InsertMeasurementClient")
                .WithTcpServer("localhost", 1884)
                .WithCleanSession()
                .Build();

            mqttClient.UseApplicationMessageReceivedHandler(x =>
            {
                try
                {
                    var payload = Encoding.UTF8.GetString(x.ApplicationMessage.Payload);

                    var datum = JsonConvert.DeserializeObject<InsertMeasurementInputDto>(payload);

                    _measurementCommandService.InsertMeasurement(datum);
                }
                catch (Exception)
                {
                }
            });

            await mqttClient.ConnectAsync(options, CancellationToken.None);

            var filter = new MqttTopicFilter
            {
                Topic = "garden/measurement"
            };

            await mqttClient.SubscribeAsync(filter);
        }
    }
}