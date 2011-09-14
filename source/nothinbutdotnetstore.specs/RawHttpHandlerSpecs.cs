 using System.Web;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(RawHttpHandler))]  
    public class RawHttpHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            RawHttpHandler>
        {
        
        }

   
        public class when_processing_an_incoming_http_context : concern
        {
            Establish c = () =>
            {
                front_controller = depends.on<IProcessRequests>();
                request_factory = depends.on<ICreateRequests>();

                a_new_request_based_on_the_incoming_context = new object();
                an_incoming_httpcontext = ObjectFactory.web.create_http_context();

                request_factory.setup(x => x.create_request_from(an_incoming_httpcontext));
            };

            Because b = () =>
                sut.ProcessRequest(an_incoming_httpcontext);


            It should_delegate_a_request_to_our_front_controller = () =>
                front_controller.received(x => x.process(a_new_request_based_on_the_incoming_context));

            static IProcessRequests front_controller;
            static object a_new_request_based_on_the_incoming_context;
            static HttpContext an_incoming_httpcontext;
            static ICreateRequests request_factory;
        }
    }
}
