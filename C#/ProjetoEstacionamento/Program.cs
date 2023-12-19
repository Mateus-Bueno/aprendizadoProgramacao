using System.Globalization;

double valorMonetario = .342;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");

Console.WriteLine($"{valorMonetario:P2}");
