using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : ICanFindCommands
    {
        IEnumerable<IProcessARequest> all_commands;

        public CommandRegistry(IEnumerable<IProcessARequest> all_commands)
        {
            this.all_commands = all_commands;
        }

        public IProcessARequest get_the_command_that_can_process(IContainRequestInformation the_request)
        {
            return all_commands.First(x => x.can_handle(the_request));
        }
    }
}