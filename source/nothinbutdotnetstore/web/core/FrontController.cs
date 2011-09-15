namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessRequests
    {
        ICanFindCommands command_finder;
        public FrontController(ICanFindCommands command_finder)
        {
            this.command_finder = command_finder;
        }
        
        public void process(IContainRequestInformation a_request)
        {
            command_finder.get_the_command_that_can_process(a_request).process(a_request);
        }

  
    }
}