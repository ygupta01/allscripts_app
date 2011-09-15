namespace nothinbutdotnetstore.web.core
{
    public class RequestHandlingCommand : IProcessARequest
    {
        RequestCriteria request_criteria;
        IPerformApplicationBehaviour application_behaviour;

        public RequestHandlingCommand(RequestCriteria request_criteria, IPerformApplicationBehaviour application_behaviour)
        {
            this.request_criteria = request_criteria;
            this.application_behaviour = application_behaviour;
        }

        public void process(IContainRequestInformation the_request)
        {
            application_behaviour.process(the_request);
        }

        public bool can_handle(IContainRequestInformation request)
        {
            return request_criteria(request);
        }
    }
}