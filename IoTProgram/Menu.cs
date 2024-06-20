internal class Menu
{
    public static void PrintMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine(@" ======= MENU ======
 1-C2D
 2-Device Twin
 3-Direct Method-> Send Message
 4-Direct Method-> Emergency STOP
 5-Direct Method-> Reset Errors
 6- Increase Production Rate by 10
 7- Decrease Production Rate by 10
 8- Set Production Rate
 0- Exit"
        );
    }
    public static async Task Execute(int feature, IOT.IotHubManager manager)
    {
        switch (feature)
        {
            case 1:
                {
                    System.Console.WriteLine("Wpisz tekst wiadomości i kliknij enter");
                    string messageText = System.Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    await manager.SendMessage(messageText, devideID);
                }
                break;
            case 2:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Daj property Name:");
                    string propertyName = Console.ReadLine() ?? string.Empty;

                    var random = new Random();
                    await manager.UpdateDesiredTwin(devideID, propertyName, random.Next());
                }
                break;
            case 3:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    var result = await manager.ExecuteDeviceMethod("SendMessages", devideID);
                    Console.WriteLine($"[Controller] Method Executed with: {result}");
                }
                break;
            case 4:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    var result = await manager.ExecuteDeviceMethod("EmergencyStop", devideID);
                    Console.WriteLine($"[Controller] Method Executed with: {result}");
                }
                break;
            case 5:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    var result = await manager.ExecuteDeviceMethod("ClearErrors", devideID);
                    Console.WriteLine($"[Controller] Method Executed with: {result}");
                }
                break;
            case 6:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    var result = await manager.ExecuteDeviceMethod("ChangeProdRateUP", devideID);
                    Console.WriteLine($"[Controller] Method Executed with: {result}");
                }
                break;
            case 7:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string devideID = System.Console.ReadLine() ?? string.Empty;

                    var result = await manager.ExecuteDeviceMethod("ChangeProdRateDOWN", devideID);
                    Console.WriteLine($"[Controller] Method Executed with: {result}");
                }
                break;
            case 8:
                {
                    Console.WriteLine("Daj ID z azure i kliknij enter");
                    string deviceID = System.Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Podaj nazwe property:");
                    string propertyName = System.Console.ReadLine() ?? string.Empty;

                    Console.WriteLine("Podaj wartosc property:");
                    string propertyValue = System.Console.ReadLine() ?? string.Empty;

                    await manager.UpdateDesiredTwin(deviceID, propertyName, propertyValue);

                }
                break;
            default:
                break;
        }

    }
    internal static int ReadInput()
    {
        var keyPressed = Console.ReadKey();
        var isParsed = int.TryParse(keyPressed.KeyChar.ToString(), out int value);
        return isParsed ? value : -1;
    }
}