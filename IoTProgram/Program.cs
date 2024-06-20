using System;
using Microsoft.Azure.Devices;
string conString = "HostName=hub777.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=CCKEN2695QiLYZJtO2Vlus4NKMckGuWnQAIoTHyQ1bQ=";
Console.WriteLine("============================================");
Console.WriteLine("[Controller] Azure Conntecting String Loaded");

using var serviceClient = ServiceClient.CreateFromConnectionString(conString);
using var registryManager = RegistryManager.CreateFromConnectionString(conString);

var manager = new IOT.IotHubManager(serviceClient, registryManager);

int input;
do
{
    Menu.PrintMenu();
    input = Menu.ReadInput();
    await Menu.Execute(input, manager);
} while (input != 0);

Console.WriteLine("[Controller] Controller End Working");
Console.WriteLine("============================================");