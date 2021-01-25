using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class  TaxRate
    {
        private decimal Min;
        private decimal Max;
        private decimal IRate;

        public decimal _Irate
        {
            get { return IRate; }
            set { IRate = value; }
        }

        public decimal _Max
        {
            get { return Max; }
            set { Max = value; }
        }


        public decimal _Min
        {
            get { return Min; }
            set { Min = value; }
        }
    }
    public class TaxYear
    {
        private int Year;
        private decimal Ceiling;

        public decimal _Ceiling
        {
            get { return Ceiling; }
            set { Ceiling = value; }
        }

        public int _Year
        {
            get { return Year; }
            set { Year = value; }
        }
    }

    public class IRateDictionary
    {
        private Dictionary<TaxYear, List<TaxRate>> TaxLane;
        public Dictionary<TaxYear, List<TaxRate>> _TaxLane
        {
            get { return TaxLane; }
            set { TaxLane = value; }
        }
        public IRateDictionary()
        {
            _TaxLane = new Dictionary<TaxYear, List<TaxRate>>();    
        }

        public static IRateDictionary LoadDictionary()
        {
            return LoadTaxeRateDataByYear();
        }

        private static IRateDictionary LoadTaxeRateDataByYear()//Load taxes from DB for instance, or even from a API
        {
            var Years = new List<TaxYear>()
            {
                // 2011
                new TaxYear()
                {
                    _Year = 2011
                     ,
                    _Ceiling = (decimal)405.86
                },
                //2012
                new TaxYear()
                {
                     _Year = 2012
                    ,
                    _Ceiling = (decimal)500.00
                }
            };
            var Rates = new List<List<TaxRate>>();
            //2011
            var rates = new List<TaxRate>()
            {
                new TaxRate()
                {
                    _Min = (decimal)0
                    ,_Max = (decimal)1106.90
                    ,_Irate = (decimal)8
                },
                new TaxRate()
                {
                    _Min = (decimal)1106.91
                    ,_Max = (decimal)1844.83
                    ,_Irate = (decimal)9
                },
                new TaxRate()
                {
                    _Min = (decimal)1844.84
                    ,_Max = (decimal)3689.66
                    ,_Irate = (decimal)11
                },
            };
            //2012
            var rates2 = new List<TaxRate>()
            {
                new TaxRate()
                {
                    _Min = (decimal)0
                    ,_Max = (decimal)1000.00
                    ,_Irate = (decimal)7
                },
                new TaxRate()
                {
                    _Min = (decimal)1000.01
                    ,_Max = (decimal)1500.00
                    ,_Irate = (decimal)8
                },
                new TaxRate()
                {
                    _Min = (decimal)1500.01
                    ,_Max = (decimal)3000.00
                    ,_Irate = (decimal)9
                },
                new TaxRate()
                {
                    _Min = (decimal)3000.01
                    ,_Max = (decimal)4000.00
                    ,_Irate = (decimal)11
                },
            };

            var RatesByYear = new IRateDictionary();
            Rates.Add(rates);
            Rates.Add(rates2);

            RatesByYear._TaxLane.Add(Years[0], Rates[0]);
            RatesByYear._TaxLane.Add(Years[1], Rates[1]);

            return RatesByYear;
        }
    }
}
