using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class CalculadorInss : ICalculadorInss
    {
        private int Year;
        private decimal Income;

        private decimal CalcularDesconto()
        {
            GetVariables(out IEnumerable<decimal> ceiling, out IEnumerable<decimal> rate);
            if (rate.FirstOrDefault() == 0)
                return ceiling.FirstOrDefault();

            return Calculo(rate.FirstOrDefault(), ceiling.FirstOrDefault());
        }

        private void GetVariables(out IEnumerable<decimal> ceiling, out IEnumerable<decimal> rate)
        {
            var taxes = RatesByYearsDictionary.LoadDictionary();
            var taxesoftheyear = taxes.TaxByYearLane.Where(s => s.Key.Year.Equals(Year));
            ceiling = taxesoftheyear.Select(s => s.Key.Ceiling);
            rate = taxesoftheyear.Where(s => s.Key.Year.Equals(Year))
                .Select(x => x.Value.Where(j => (double)Income >= (double)j.Min && (double)Income <= (double)j.Max)
                .Select(y => y.Rate).FirstOrDefault());
        }

        private decimal Calculo(decimal rate, decimal ceiling)
        {
            return Math.Round(this.Income * (rate / 100) >= ceiling ? ceiling : this.Income * (rate / 100), 2);
        }

        /// <summary>
		/// Deve retornar o deconto do INSS aplicado ao salário, na determinada data.
		/// </summary>
		public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            this.Year = data.Year;
            this.Income = salario;
            return CalcularDesconto();
        }
    }
}
