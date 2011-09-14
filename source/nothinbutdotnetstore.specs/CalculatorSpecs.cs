using System;
using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Calculator))]
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<ICalculate,Calculator>
        {
        }

        public class when_created : concern
        {
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
            };

            It should_not_open_the_connection = () =>
                connection.never_received(x => x.Open());

            static IDbConnection connection;
        }

        public class FakeConnection : IDbConnection
        {
            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public IDbTransaction BeginTransaction()
            {
                throw new NotImplementedException();
            }

            public IDbTransaction BeginTransaction(IsolationLevel il)
            {
                throw new NotImplementedException();
            }

            public void Close()
            {
                throw new NotImplementedException();
            }

            public void ChangeDatabase(string databaseName)
            {
                throw new NotImplementedException();
            }

            public IDbCommand CreateCommand()
            {
                throw new NotImplementedException();
            }

            public void Open()
            {
                throw new NotImplementedException();
            }

            public string ConnectionString
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public int ConnectionTimeout
            {
                get { throw new NotImplementedException(); }
            }

            public string Database
            {
                get { throw new NotImplementedException(); }
            }

            public ConnectionState State
            {
                get { throw new NotImplementedException(); }
            }
        }
        public class when_adding_two_positive_numbers : concern
        {
            //Arrange
            Establish c = () =>
            {
                connection = depends.on<IDbConnection>();
                depends.on(2);

                command = fake.an<IDbCommand>();

                connection.setup(x => x.CreateCommand()).Return(command);
            };

            //Act
            Because b = () =>
                result = sut.add(2, 3);

            //Assert
            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_stored_procedure = () =>
                command.received(x => x.ExecuteNonQuery());

            It should_dispose_its_resources = () =>
            {
                connection.received(x => x.Dispose());
                command.received(x => x.Dispose());
            };
                
                

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }

        public class when_enabling_super_mode : concern
        {
            Establish c = () =>
            {
                fake_principal = fake.an<IPrincipal>();

                fake_principal.setup(x => x.IsInRole(Arg<string>.Is.Anything))
                    .Return(false);

                spec.change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                spec.catch_exception(() => sut.enable_super_mode());


            It should_not_be_allowed_if_they_are_no_in_the_correct_role = () =>
                spec.exception_thrown.ShouldBeAn<SecurityException>();

            static IPrincipal fake_principal;
        }
        public class when_attempting_to_add_a_negative_number : concern
        {
            Because b = () =>
                spec.catch_exception(() => sut.add(-2, 3));

            It should_throw_an_argument_exception = () =>
                spec.exception_thrown.ShouldBeAn<ArgumentException>();

        }
    }
}