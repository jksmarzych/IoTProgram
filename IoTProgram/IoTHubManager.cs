using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT
{
    public class IotHubManager
    {
        private readonly ServiceClient client;
        private readonly RegistryManager registry;
        public IotHubManager(ServiceClient client, RegistryManager registry)
        {
            this.client = client;
            this.registry = registry;
        }
        public async Task SendMessage(string textMessage, string deviceId)
        {
            var messageBody = new { text = textMessage };
            var message = new Microsoft.Azure.Devices.Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageBody)));
            message.MessageId = Guid.NewGuid().ToString();
            await client.SendAsync(deviceId, message);
        }
        public async Task<int> ExecuteDeviceMethod(string methodName, string deviceId)
        {
            var method = new CloudToDeviceMethod(methodName);

            var result = await client.InvokeDeviceMethodAsync(deviceId, method);
            return result.Status;
        }
        public async Task UpdateDesiredTwin(string deviceId, string propertyName, dynamic propertyValue)
        {
            var twin = await registry.GetTwinAsync(deviceId);
            twin.Properties.Desired[propertyName] = propertyValue;
            await registry.UpdateTwinAsync(twin.DeviceId, twin, twin.ETag);
        }

    }
}
