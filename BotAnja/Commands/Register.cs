using BotAnja.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotAnja.Commands
{
    class Register:BaseCommand
    {
        public Register()
        {

        }

        public override async Task Invoke(Message message, TelegramBotClient bot)
        {
            await Dictionaries.States[(int)Enums.States.Register].Invoke(message,bot);
            await Task.CompletedTask;
        }
    }
}
