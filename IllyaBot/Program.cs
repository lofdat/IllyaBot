using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IllyaBot
{
    public static class IllyaSelfBot
    {
        static void Main(string[] args)
        {
            Login(args).GetAwaiter().GetResult();
        }
        public static DiscordSocketClient Client;
        public static async Task Login(string[] clargs)
        {
            Client = new DiscordSocketClient();

            Client.MessageReceived += HandleMessage;
            Client.Ready += Ready;
            StreamReader Reader = File.OpenText(@"./cred.json");
            JsonTextReader TReader = new JsonTextReader(Reader);
            JObject ObjectReader = (JObject)JToken.ReadFrom(TReader);
            Dictionary<string, string> Credentials = JsonConvert.DeserializeObject<Dictionary<string, string>>(ObjectReader.ToString());
            await Client.LoginAsync(TokenType.User, Credentials["token"]);
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        public static async Task HandleMessage(SocketMessage Message)
        {
            if (Message.Author.Id != 255950165200994307) return;
            if (Message.Content == "i.lenny")
            {
                await Message.Channel.SendMessageAsync("( ͡° ͜ʖ ͡°)");
                await Message.DeleteAsync();
            }
            else if (Message.Content == "i.bear")
            {
                await Message.Channel.SendMessageAsync("ʕ•ᴥ•ʔ");
                await Message.DeleteAsync();
            }
            else if (Message.Content == "i.fite")
            {
                await Message.Channel.SendMessageAsync("(ง ͠° ͟ل͜ ͡°)ง");
                await Message.DeleteAsync();
            }
            else if (Message.Content == "i.hug")
            {
                await Message.Channel.SendMessageAsync("༼ つ ◕_◕ ༽つ");
                await Message.DeleteAsync();
            }
            else if (Message.Content == "i.wot")
            {
                await Message.Channel.SendMessageAsync("ಠ_ಠ");
                await Message.DeleteAsync();
            }
        }
        public static async Task Ready()
        {
            Console.WriteLine("ready");
            await Task.CompletedTask;
        }
    }
}
