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
        private decimal Discount;
        public decimal _Discount
        {
            get { return Discount; }
            set { Discount = value; }
        }


        public decimal _Income
        {
            get { return Income; }
            set { Income = value; }
        }

        public int _Year
        {
            get { return Year; }
            set { Year = value; }
        }

        private decimal _CalcularDesconto()
        {
            IEnumerable<decimal> ceiling, rate;
            GetVariables(out ceiling, out rate);
            if (rate.FirstOrDefault() == 0)
                return ceiling.FirstOrDefault();

            return Calculo(rate.FirstOrDefault(), ceiling.FirstOrDefault());
        }

        private void GetVariables(out IEnumerable<decimal> ceiling, out IEnumerable<decimal> rate)
        {
            var taxes = IRateDictionary.LoadDictionary();
            var taxesoftheyear = taxes._TaxLane.Where(s => s.Key._Year.Equals(Year));
            ceiling = taxesoftheyear.Select(s => s.Key._Ceiling);
            rate = taxesoftheyear.Where(s => s.Key._Year.Equals(Year))
                .Select(x => x.Value.Where(j => (double)_Income >= (double)j._Min && (double)_Income <= (double)j._Max)
                .Select(y => y._Irate).FirstOrDefault());
        }

        private decimal Calculo(decimal rate, decimal ceiling)
        {
            return this._Income * (rate / 100) >= ceiling ? ceiling : this._Income * (rate / 100); ;
        }

        /// <summary>
		/// Deve retornar o deconto do INSS aplicado ao salário, na determinada data.
		/// </summary>
		public decimal CalcularDesconto(DateTime data, decimal salario)
        {
            this.Year = data.Year;
            this.Income = salario;
            return _CalcularDesconto();
        }

        
    }
}
