using System;
using System.Collections.Generic;

namespace ConsoleClient
{
    public class CommandFactory
    {
        private readonly Dictionary<Type, Func<object, ICommand>> commands = new Dictionary
            <Type, Func<object, ICommand>>
        {
            {typeof (SetSubOptions), options => new SetCommand(options)},
            {typeof (PredictSubOptions), options => new PredictCommand(options)},
        };

        public ICommand CreateCommand(object verbInstance)
        {
            Func<object, ICommand> commandCreate;
            if (commands.TryGetValue(verbInstance.GetType(), out commandCreate))
            {
                return commandCreate(verbInstance);
            }
            throw new NotSupportedException(String.Format("Command not found for {0} options",
                verbInstance.GetType().Name));
        }
    }
}