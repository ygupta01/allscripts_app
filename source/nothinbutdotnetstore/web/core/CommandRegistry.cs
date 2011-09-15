namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : ICanFindCommands
    {
        public IProcessARequest get_the_command_that_can_process(IContainRequestInformation the_request)
        {
            throw new System.NotImplementedException();
        }
    }
}