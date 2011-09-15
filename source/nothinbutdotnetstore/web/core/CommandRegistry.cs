using System.Linq;
namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : ICanFindCommands
    {

        public IProcessARequest get_the_command_that_can_process(IContainRequestInformation the_request)
        {
           return this.get_the_command_that_can_process(the_request);          
           
        }
    }
}