namespace INSS
{
    public class YearOfTax
    {
        private int TaxYear;
        private decimal TaxCeiling;

        public decimal Ceiling
        {
            get { return TaxCeiling; }
            set { TaxCeiling = value; }
        }

        public int Year
        {
            get { return TaxYear; }
            set { TaxYear = value; }
        }
    }
}
