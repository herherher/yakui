using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;

namespace Yakui_the_maid
{
    class Program
    {
        static DiscordClient discord;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string prefix = "??";

            string[] config = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "\\token1.txt");
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = config[0],
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug

            });

            discord.MessageCreated += async e =>
            {
                string[] commands = new string[] {"help"};
                foreach(string command in commands){
                    if(e.Message.Content.StartsWith(prefix + command) && command == "help")
                    {
                        await e.Message.RespondAsync("Here is a list of the currently available commands:\n??help: prints out this list.\n??idk");
                    }
                }
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
