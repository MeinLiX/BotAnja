using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotAnja.Utils
{
    static class Markup
    {
        internal static async Task SendMsg(Message message, string ans, TelegramBotClient bot)
        {
            await bot.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: ans
            );
        }
        internal static class Keybord
        {

            internal static ReplyKeyboardMarkup example = new ReplyKeyboardMarkup(
               new KeyboardButton[][]
               {
                        new KeyboardButton[] { "AAA", "BBB" },
                        new KeyboardButton[] { "CCC", "DDD" },
               },
               resizeKeyboard: true
            );

            internal static ReplyKeyboardRemove Remove = new ReplyKeyboardRemove();

            internal static async Task Send(Message message, string msgText, IReplyMarkup KbM, TelegramBotClient bot)
            {
                if (KbM == null || msgText == null) return;

                await bot.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: msgText,
                    replyMarkup: KbM
                );
            }

            internal static class Inline
            {
                internal static InlineKeyboardMarkup example = new InlineKeyboardMarkup(new[]
                {
                     new []
                     {
                         InlineKeyboardButton.WithCallbackData("AAA", "aa"),
                         InlineKeyboardButton.WithCallbackData("BBB", "bb"),
                     },
                     new []
                     {
                         InlineKeyboardButton.WithCallbackData("CCC", "cc"),
                         InlineKeyboardButton.WithCallbackData("DDD", "dd"),
                     }
                });

                internal static async Task Send(Message message, string msgText, IReplyMarkup IKbM, TelegramBotClient bot)
                {
                    if ((IKbM as InlineKeyboardMarkup) == null || msgText == null) return;

                    await bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(250);

                    await bot.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: msgText,
                        replyMarkup: IKbM
                    );
                }
            }
        }
    }
}
