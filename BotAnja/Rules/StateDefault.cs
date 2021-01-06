using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using BotAnja.Utils;

namespace BotAnja.Rules
{
    class StateDefault : BaseRule
    {
        public StateDefault()
        {
        }


        public override async Task Invoke(object message, TelegramBotClient bot)
        {
            Message msg = message as Message;
            if (Dictionaries.Commands.TryGetValue(msg.Text.Split(' ').First().ToLower(), out var Command))
            {
                await Command.Invoke(msg, bot);
            }
            else
            {
                await Markup.SendMsg(msg, $"You wrote me: {msg.Text}", bot);
            }
            await Task.CompletedTask;
        }

        public override async Task InvokeCallbackQueryReceived(object message, TelegramBotClient bot)
        {
            await Task.CompletedTask;
        }

        public override async Task InvokeChosenInlineResultReceived(object message, TelegramBotClient bot)
        {
            await Task.CompletedTask;
        }

        public override async Task InvokeMessageReceived(object message, TelegramBotClient bot)
        {
            await Task.CompletedTask;
        }
    }
}
