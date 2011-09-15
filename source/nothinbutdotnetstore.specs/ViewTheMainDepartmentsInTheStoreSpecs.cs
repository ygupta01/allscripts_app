using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IPerformApplicationBehaviour,
                                            ViewTheMainDepartmentsInTheStore>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
            };

            Because b = () =>
                sut.process(request);


            It should_get_a_list_of_the_main_departments_in_the_store = () =>
            {

            };
                

            static IContainRequestInformation request;
        }
    }
}