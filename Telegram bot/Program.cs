using Newtonsoft.Json.Linq;

string token =
    "https://api.telegram.org/bot5959064399:AAGrZz1hnwOHaFtnpqkVJK3-0tKN-YHDNt0/getUpdates";

Bot.Init(token);
Bot.Start();

Console.ReadLine();
