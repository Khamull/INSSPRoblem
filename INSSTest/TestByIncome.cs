using INSS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace INSSTest
{
    [TestClass]
    public class TestByIncome
    {
        [TestMethod]
        public void TestByIncome2011()
        {
            ICalculadorInss calc = new CalculadorInss();
            var descI = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)1106.90);
            var descII = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)1106.91);
            var descIII = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)1844.83);
            var descIV = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)1844.84);
            var descV = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)3689.66);
            Assert.IsNotNull(descI);
            Assert.IsTrue(Decimal.TryParse(descI.ToString(), out _));
            Assert.IsTrue(descI == (decimal)88.55);

            Assert.IsNotNull(descII);
            Assert.IsTrue(Decimal.TryParse(descII.ToString(), out _));
            Assert.IsTrue(descII == (decimal)99.62);

            Assert.IsNotNull(descIII);
            Assert.IsTrue(Decimal.TryParse(descIII.ToString(), out _));
            Assert.IsTrue(descIII == (decimal)166.03);

            Assert.IsNotNull(descIV);
            Assert.IsTrue(Decimal.TryParse(descIV.ToString(), out _));
            Assert.IsTrue(descIV == (decimal)202.93);

            Assert.IsNotNull(descV);
            Assert.IsTrue(Decimal.TryParse(descV.ToString(), out _));
            Assert.IsTrue(descV == (decimal)405.86);
        }

        [TestMethod]
        public void TestByCeilling2011()
        {
            ICalculadorInss calc = new CalculadorInss();
            var descI = calc.CalcularDesconto(DateTime.Parse("2011-01-01"), (decimal)4000.00);
            Assert.IsNotNull(descI);
            Assert.IsTrue(Decimal.TryParse(descI.ToString(), out _));
            Assert.IsTrue(descI == (decimal)405.86);
        }

        [TestMethod]
        public void TestByCeilling2012()
        {
            ICalculadorInss calc = new CalculadorInss();
            var descI = calc.CalcularDesconto(DateTime.Parse("2012-01-01"), (decimal)4001.00);
            Assert.IsNotNull(descI);
            Assert.IsTrue(Decimal.TryParse(descI.ToString(), out _));
            Assert.IsTrue(descI == (decimal)500.00);
        }
    }
}
