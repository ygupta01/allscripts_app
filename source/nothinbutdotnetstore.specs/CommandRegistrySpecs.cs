using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(CommandRegistry))]
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<ICanFindCommands,
                                            CommandRegistry>
        {
        }

        public class when_finding_the_command_that_can_process_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                all_the_commands = Enumerable.Range(1,100).Select(x => fake.an<IProcessARequest>()).ToList();
                the_command_that_can_process_the_request = fake.an<IProcessARequest>();

                request = fake.an<IContainRequestInformation>();
                all_the_commands.Add(the_command_that_can_process_the_request);

                the_command_that_can_process_the_request.setup(x => x.can_handle(request))
                    .Return(true);

                depends.on<IEnumerable<IProcessARequest>>(all_the_commands);
            };

            Because b = () =>
                result = sut.get_the_command_that_can_process(request);

            It should_return_the_command_to_the_caller = () =>
                result.ShouldEqual(the_command_that_can_process_the_request);

            static IProcessARequest result;
            static IProcessARequest the_command_that_can_process_the_request;
            static IContainRequestInformation request;
            static IList<IProcessARequest> all_the_commands;
        }
    }

}