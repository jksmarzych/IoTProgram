using System;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices;
using IOT_Device;


string conString = "HostName=hub777.azure-devices.net;DeviceId=device1;SharedAccessKey=bFTPJmi0cE2NAWHFDwUsTgfizCfIjwzgDAIoTMILmdA=";
Console.WriteLine("============================================");
Console.WriteLine("[Agent] Azure Conntecting String Loaded");

using var deviceClient = DeviceClient.CreateFromConnectionString(conString);
await deviceClient.OpenAsync();
var device = new MyDevice(deviceClient);
Console.WriteLine("[Agent] Connection with Device Established");
await device.InitializerHandlers();
await device.UpdateTwinAsync();
Console.WriteLine("[Agent] Start Working...");
Console.WriteLine("");
Console.WriteLine("");
await device.SendMessages(2, 1000);
var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(10));
while (await periodicTimer.WaitForNextTickAsync())
{
    await device.TimerSendingMessages();
}