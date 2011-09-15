using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(FrontController))]
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<IProcessRequests,
                                            FrontController>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = depends.on<ICanFindCommands>();
                the_request = fake.an<IContainRequestInformation>();
                command_that_can_handle_the_request = fake.an<IProcessARequest>();

                command_registry.setup(x => x.get_the_command_that_can_process(the_request))
                    .Return(command_that_can_handle_the_request);

            };

            Because b = () =>
                sut.process(the_request);

            It should_delegate_the_processing_to_the_command_that_can_run_the_request = () =>
                command_that_can_handle_the_request.received(x => x.process(the_request));

            static IProcessARequest command_that_can_handle_the_request;
            static IContainRequestInformation the_request;
            static ICanFindCommands command_registry;
        }
    }

}