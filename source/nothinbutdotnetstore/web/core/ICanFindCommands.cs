namespace nothinbutdotnetstore.web.core
{
    public interface ICanFindCommands
    {
        IProcessARequest get_the_command_that_can_process(IContainRequestInformation the_request);
    }
}