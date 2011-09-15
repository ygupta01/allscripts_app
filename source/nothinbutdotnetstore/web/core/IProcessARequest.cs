namespace nothinbutdotnetstore.web.core
{
    public interface IProcessARequest
    {
        void process(IContainRequestInformation the_request);
        bool can_handle(IContainRequestInformation request);
    }
}