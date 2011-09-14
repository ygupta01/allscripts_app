using System;
using System.Data;
using System.Linq;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public interface ICalculate
    {
        int add(int first, int second);
        void enable_super_mode();
    }

    public class Calculator : ICalculate
    {
        IDbConnection connection;

        public Calculator(IDbConnection connection,int number)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            ensure_all_are_positive(first, second);

            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            return first + second;
        }

        public void enable_super_mode()
        {
            if (Thread.CurrentPrincipal.IsInRole("sfsdf")) return;

            throw new SecurityException();
        }

        void ensure_all_are_positive(params int[] numbers)
        {
            if (numbers.All(x => x > 0)) return;

            throw new ArgumentException();
        }
    }
}