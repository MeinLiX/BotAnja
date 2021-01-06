using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotAnja.Commands
{
    class RemoveKeyboard : BaseCommand
    {
        public RemoveKeyboard()
        {

        }

        public override async Task Invoke(Message message, TelegramBotClient bot)
        {
            await Utils.Markup.Keybord.Send(message, "Keyboard is removed.", Utils.Markup.Keybord.Remove, bot);
            await Task.CompletedTask;
        }
    }
}
