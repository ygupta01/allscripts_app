using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(RequestHandlingCommand))]
    public class RequestHandlingCommandSpecs
    {
        public abstract class concern : Observes<IProcessARequest,
                                            RequestHandlingCommand>
        {
        }

        public class when_determining_if_it_can_process_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                depends.on<RequestCriteria>(x => true);
            };

            Because b = () =>
                result = sut.can_handle(request);

            It should_make_the_determination_by_using_its_request_specification = () =>
                result.ShouldBeTrue();

            static bool result;
            static IContainRequestInformation request;
        }
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                application_behaviour = depends.on<IPerformApplicationBehaviour>();
            };

            Because b = () =>
                sut.process(request);

            It should_trigger_the_application_specific_functionality = () =>
                application_behaviour.received(x => x.process(request));

            static IContainRequestInformation request;
            static IPerformApplicationBehaviour application_behaviour;
        }
    }
}