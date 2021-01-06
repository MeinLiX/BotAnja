using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotAnja.Commands
{
    abstract class BaseCommand
    {
        public BaseCommand()
        {
        }

        public abstract Task Invoke(Message message, TelegramBotClient bot);
    }
}
