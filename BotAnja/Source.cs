using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using BotAnja.Utils;
using System.Linq;

namespace BotAnja
{
    class Source
    {
        private readonly TelegramBotClient bot;

        public Source(TelegramBotClient bot) => this.bot = bot;

        public async Task UpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var handler = update.Type switch
            {
                UpdateType.Message => BotOnMessageReceived(update.Message),
                UpdateType.EditedMessage => BotOnMessageReceived(update.EditedMessage),
                //UpdateType.CallbackQuery => default,
                //UpdateType.InlineQuery => default,
                //UpdateType.ChosenInlineResult => default,
                //UpdateType.Unknown=> default,
                //UpdateType.ChannelPost=> default,
                //UpdateType.EditedChannelPost=> default,
                //UpdateType.ShippingQuery=> default,
                //UpdateType.PreCheckoutQuery=> default,
                //UpdateType.Poll=> default,
                _ => UnknownUpdateHandlerAsync(update)
            };

            try
            {
                await handler;
            }
            catch (Exception exception)
            {
                await ErrorAsync(botClient, exception, cancellationToken);
            }
        }

        private async Task BotOnMessageReceived(Message message)
        {
            Console.WriteLine($"Receive message type: {message.Type}, from: {message.From.Username}");
            if (message.Type != MessageType.Text)
                return;

            DB.Models.User user = DB.Controllers.MainController.Users.GetFirstUser(message.From.Id);
            if (user != null)
            {
                if (Dictionaries.States.TryGetValue(user.State, out var actionState))
                {
                    await actionState.Invoke(message, bot);
                }
            }
            else if (message.Text.Split(' ').First() == "/register")
            {
                if (Dictionaries.Commands.TryGetValue(message.Text.Split(' ').First(), out var Command))
                {
                    await Command.Invoke(message, bot);
                }
            }
            else
            {
                await Markup.SendMsg(message, "You are not registered.\nPlease /register", bot);
            }
        }

#pragma warning disable CS1998
        private async Task UnknownUpdateHandlerAsync(Update update)
#pragma warning restore CS1998
        {
            Console.WriteLine($"Unknown update type: {update.Type}");
        }

#pragma warning disable CS1998
        public async Task ErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
#pragma warning restore CS1998
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
        }
    }
}
