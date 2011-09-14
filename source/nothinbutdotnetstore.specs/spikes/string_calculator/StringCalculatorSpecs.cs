using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace nothinbutdotnetstore.specs.spikes.string_calculator
{
    [Subject(typeof(StringCalculator))]
    public class StringCalculatorSpecs
    {
        public abstract class concern : Observes<StringCalculator>
        {
        }

        public class when_observation_name : concern
        {
            It first_observation = () => 
        }
    }

    public class StringCalculator
    {
    }
}