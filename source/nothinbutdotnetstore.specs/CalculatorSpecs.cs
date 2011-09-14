using System;
using System.Data;
using Machine.Specifications;
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
                

            It should_return_the_sum = () =>
                result.ShouldEqual(5);

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
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