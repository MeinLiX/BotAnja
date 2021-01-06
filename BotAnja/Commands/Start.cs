using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotAnja.Commands
{
    class Start:BaseCommand
    {
        public Start()
        {

        }

        public override async Task Invoke(Message message, TelegramBotClient bot) 
        {
            await Utils.Markup.Keybord.Inline.Send(message,"My Test ans by /start",Utils.Markup.Keybord.Inline.example,bot);
            await Task.CompletedTask;
        }
    }
}
