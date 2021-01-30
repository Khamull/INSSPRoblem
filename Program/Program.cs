using INSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculadorInss calc = new CalculadorInss();

            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)1000.00));
            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2012-01-01"), (decimal)1000.00));

            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)3000.00));
            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2012-01-01"), (decimal)3000.00));

            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)4000.00));
            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2012-01-01"), (decimal)4000.00));

            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)10000.00));
            Console.WriteLine(calc.CalcularDesconto(DateTime.Parse("2012-01-01"), (decimal)10000.00));
            Console.ReadKey();

        }
    }
}
