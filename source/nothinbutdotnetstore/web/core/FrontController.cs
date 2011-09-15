namespace nothinbutdotnetstore.web.core
{
    public class FrontController : IProcessRequests
    {
        ICanFindCommands command_registry;

        public FrontController(ICanFindCommands command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestInformation a_request)
        {
            command_registry.get_the_command_that_can_process(a_request).process(a_request);
        }
    }
}