using System.Collections.Generic;
using BotAnja.Commands;
using BotAnja.Rules;

namespace BotAnja.Utils
{
    class Dictionaries
    {
        internal static Dictionary<string, BaseCommand> Commands = new Dictionary<string, BaseCommand>()
        {
            ["/register"] = new Register(),
            ["/start"] = new Start(),
            ["/removekeyboard"] = new RemoveKeyboard(),
        };

        internal static Dictionary<int, BaseRule> States = new Dictionary<int, BaseRule>()
        {
            [(int)Enums.States.Register] = new StateRegister(),
            [(int)Enums.States.Default] = new StateDefault(),
        };
    }
}
