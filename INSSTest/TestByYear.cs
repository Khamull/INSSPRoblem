using INSS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace INSSTest
{
    [TestClass]
    public class TestByYear
    {
        [TestMethod]
        public void Year2011()
        {
            ICalculadorInss calc = new CalculadorInss();
            var desc = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)1000.00);
            Assert.IsNotNull(desc);
            Assert.IsTrue(Decimal.TryParse(desc.ToString(), out _));
            Assert.IsTrue(desc == 80);
        }

        [TestMethod]
        public void Year2012()
        {
            ICalculadorInss calc = new CalculadorInss();
            var desc = calc.CalcularDesconto(DateTime.Parse("2012-01-01"), (decimal)1000.00);
            Assert.IsNotNull(desc);
            Assert.IsTrue(Decimal.TryParse(desc.ToString(), out _));
            Assert.IsTrue(desc == 70);
        }

        [TestMethod]
        public void Year2013()
        {
            ICalculadorInss calc = new CalculadorInss();
            var desc = calc.CalcularDesconto(DateTime.Parse("2013-01-01"), (decimal)1000.00);
            Assert.IsNotNull(desc);
            Assert.IsTrue(Decimal.TryParse(desc.ToString(), out _));
            Assert.IsTrue(desc == 0);
        }
    }
}
