using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotAnja.Rules
{
    class StateRegister : BaseRule
    {
        public override async Task Invoke(object message, TelegramBotClient bot)
        {
            Message msg = message as Message;
            DB.Models.User newUser = new DB.Models.User(msg.From.Id, msg.From.Username, (int)Utils.Enums.States.Default);
            if (DB.Controllers.MainController.Users.GetFirstUser(newUser.Id) != null)
            {
                await Utils.Markup.SendMsg(msg, $"User {newUser.Username} already authorized.", bot);
            }
            else if (DB.Controllers.MainController.Users.AddUser(newUser).Result)
            {
                await Utils.Markup.SendMsg(msg, $"Welcome {newUser.Username}!\nYou are authorized.", bot);
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
