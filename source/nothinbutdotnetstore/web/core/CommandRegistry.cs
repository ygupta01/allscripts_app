using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : ICanFindCommands
    {
        IEnumerable<IProcessARequest> all_commands;
        IProcessARequest the_special_case;

        public CommandRegistry(IEnumerable<IProcessARequest> all_commands, IProcessARequest the_special_case)
        {
            this.all_commands = all_commands;
            this.the_special_case = the_special_case;
        }

        public IProcessARequest get_the_command_that_can_process(IContainRequestInformation the_request)
        {
            foreach(IProcessARequest r in all_commands)
            {
                if (r.can_handle((the_request)))
                {
                    return r;
                }
            }

            return the_special_case;
        }
    }
}