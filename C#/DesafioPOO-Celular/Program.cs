using DesafioPOO.Models;

// TODO: Realizar os testes com as classes Nokia e Iphone

Console.WriteLine("Smartphone Nokia:");
Smartphone nokia = new Nokia("(11)99999-9999", "Modelo a", "111111111111111", 64);
nokia.Ligar();
nokia.InstalarAplicativo("Whatsapp");

Console.WriteLine("\n");

Console.WriteLine("Smartphone iPhone:");
Smartphone iphone = new Iphone("(11)93333-3333", "Modelo b", "222222222222222", 256);
iphone.ReceberLigacao();
iphone.InstalarAplicativo("Telegram");