using System.Threading.Tasks;
using Telegram.Bot;

namespace BotAnja.Rules
{
    abstract class BaseRule
    {
        public BaseRule()
        {
        }

        public abstract Task Invoke(object message, TelegramBotClient bot);
        public abstract Task InvokeMessageReceived(object message, TelegramBotClient bot);
        public abstract Task InvokeCallbackQueryReceived(object message, TelegramBotClient bot);
        public abstract Task InvokeChosenInlineResultReceived(object message, TelegramBotClient bot);
    }
}
