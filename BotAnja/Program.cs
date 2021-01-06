using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace BotAnja
{
    class Program
    {
        private TelegramBotClient bot;
        private Source source;
        private static async Task Main(string[] args) => await new Program().RunBot().ConfigureAwait(false);

        public async Task RunBot()
        {
            bot = new TelegramBotClient(Configuration.BotToken);
            source = new Source(bot);

            var me = await bot.GetMeAsync();
            Console.Title = me.Username;

            var cts = new CancellationTokenSource();

            bot.StartReceiving(new DefaultUpdateHandler(source.UpdateAsync, source.ErrorAsync), cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }
    }
}
