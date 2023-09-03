
public struct Bot
{
    static string token;
    static string baseUri;

    static HttpClient hc = new HttpClient();

    // string url = "https://api.telegram.org/bot5386117434:AAF0u-IWVi5OkiIjEQYCt6r0E6Lm6mLPHeE/getUpdates";
    // string json = hc.GetStringAsync(url).Result;
    // JsonParse.Init(json);
    public static void Start()
    {
        int offset = 0;
        while (true)
        {
            
            string url = $"{baseUri}getUpdates?offset={offset}";

            string json = hc.GetStringAsync(url).Result;
            System.Console.WriteLine(json);

            JsonParse.Init(json);
            List<ModelMessage> msgs = JsonParse.Parse();
            DateTime dateTime = new DateTime();
            string t = Convert.ToString(DateTime.Now);
            foreach (ModelMessage msg in msgs)
            {
                // {
                //     SendMessage(
                //         msg.Id,
                //         "Здравствуйте, вы обратились в фирму 'Современная нумизматика', дождитесь ответа.Нажмите 1 для обращения к сотруднику поддержки,если нажмёте 2 то перейдёте в отдел русских монет,если 3 то в отдел современных иностранных монет",msg.MessageId);
                // }
                // offset = (Int32.Parse(msg.UpdateId) + 1);
                // System.Console.WriteLine(offset);
                // Repository.Append(msg);
                // Thread.Sleep(200);

                // if (msg.Id == "1") {"Вы обращаетесь к сотруднику поддержки наших клиентов"};
                // if (msg.Id == "2") {"Вы в отделе современных Русских монет, дождитесь звонка"};
                // if (msg.Id == "3") {"Вы в отделе современных иностранных монет"};

                // System.Console.WriteLine(msg);
                Repository.Append(msg);
                string uid = msg.UserId;
                string msgText = String.Empty;
                
                if (!Game.db.ContainsKey(uid) || msg.MessageText == "/restart")
                {
                    int price = 200;
                    if (!Game.db.ContainsKey(uid))Game.db.Add(uid, 0);
                    Game.db[uid] = price;
                    msgText = $"Здравствуйте, приветсвуем вас на нашем сайте современная нумизматика!Для того чтобы участвовать в онлайн торгах отправьте вашу цену ";
                }
                
               
                int user = 0;
                int price2 = 200;
                bool flag = int.TryParse(msg.MessageText, out user);
                {   

                    
                    
                    if (!flag) { msgText += $"Введите вашу стоимость лота\n"; }
                    if (user > price2)
                    {
                        Game.db[msg.UserId] =+ user;             
                        
                    }
                    var pricefinal = Game.db[msg.UserId];
                    if (pricefinal >= price2 * 3) 
                        {
                            msgText += $"Ура, вы выиграли торги. Поздравляем вас!Свой лот вы можете забрать связавшись с нами по телефону 81234567889\n";
                            
                        }
                    else
                    {
                        //    SendMessage(uid, $"Число кривое", msg.MessageId);
                        msgText += $"Введите ставку превышающую нынешнюю\n";
                        
                    }
                    
                    
                        
                
                
                // var finish = Game.db[msg.UserId];
                // if (finish >= price2 * 3)
                // {break;} 
                msgText += $"Лот № 000010 Цена лота: {Game.db[uid]}.\n Назначайте свою цену,\n у вас есть 30 секунд с этой даты {t}\n перезапуск /restart";
                SendMessage(uid, msgText, msg.MessageId);
                // msgText += $"Конфет осталось: {Game.db[uid]}.\n Возьмите от 1 до 4";
                // SendMessage(msg.UserId, msg.MessageText, msg.MessageId);
                // if (msg.Id == "1") {"Вы обращаетесь к сотруднику поддержки наших клиентов"};
                // if (msg.Id == "2") {"Вы в отделе современных Русских монет, дождитесь звонка"};
                // if (msg.Id == "3") {"Вы в отделе современных иностранных монет"};
                offset = (Int32.Parse(msg.UpdateId) + 1);
                // System.Console.WriteLine(offset);
                // Thread.Sleep(200);

                Repository.Save();
            }
            Thread.Sleep(2000);
        }
    
    }
    }
    public static void Init(string publicToken)
    {
        token = publicToken;
        baseUri = "https://api.telegram.org/bot5959064399:AAGrZz1hnwOHaFtnpqkVJK3-0tKN-YHDNt0/";
    }

    public static void SendMessage(string id, string text, string replyToMessageId = "")
    {
        string url =
            $"{baseUri}SendMessage?chat_id={id}&text={text}&reply_to_message_id={replyToMessageId}";
        var req = hc.GetStringAsync(url).Result;
    }
}
