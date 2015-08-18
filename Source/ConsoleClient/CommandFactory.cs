using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class CommandFactory
    {
        private Dictionary<Type, Func<object, ICommand>> commands = new Dictionary<Type, Func<object, ICommand>>
        {
            {typeof(SetSubOptions), (options) => new SetCommand(options)},
            {typeof(PredictSubOptions), (options) => new PredictCommand(options)},
        };

        public ICommand CreateCommand(object verbInstance)
        {
            Func<object, ICommand> commandCreate;
            if (commands.TryGetValue(verbInstance.GetType(), out commandCreate))
            {
                return commandCreate(verbInstance);
            }
            throw new NotSupportedException(String.Format("Command not found for {0} options", verbInstance.GetType().Name));
        }
    }
}
