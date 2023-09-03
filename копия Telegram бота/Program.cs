using Newtonsoft.Json.Linq;
string token ="https://api.telegram.org/bot5959064399:AAGrZz1hnwOHaFtnpqkVJK3-0tKN-YHDNt0/getUpdates";
// Repository.Load();
Bot.Init(token);
Bot.Start();


Console.ReadLine();

// JsonParse.Init( new HttpClient().GetStringAsync($"https://api.telegram.org/bot5386117434:AAF0u-IWVi5OkiIjEQYCt6r0E6Lm6mLPHeE/getUpdates").Result);

// List<ModelMessage> msgs = JsonParse.Parse();
// for (int i = 0; i < msgs.Count; i++)
// {
//     System.Console.WriteLine(ModelMessage.ToString(msgs[i]));
// }

// Bot.Init(token);
// Bot.SendMessage("1121648600","вафельный гараж?");
