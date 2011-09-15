namespace nothinbutdotnetstore.web.core
{
    public interface IProcessARequest : IPerformApplicationBehaviour
    {
        bool can_handle(IContainRequestInformation request);
    }
}