namespace INSS
{
    public class  TaxRate
    {
        private decimal MinRate;
        private decimal MaxRate;  
        private decimal taxRate;

        public decimal Rate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }

        public decimal Max
        {
            get { return MaxRate; }
            set { MaxRate = value; }
        }


        public decimal Min
        {
            get { return MinRate; }
            set { MinRate = value; }
        }
    }
}
