using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSS
{
    public class RatesByYearsDictionary
    {
        private Dictionary<YearOfTax, List<TaxRate>> TaxLane;
        public Dictionary<YearOfTax, List<TaxRate>> TaxByYearLane
        {
            get { return TaxLane; }
            set { TaxLane = value; }
        }
        public RatesByYearsDictionary()
        {
            TaxLane = new Dictionary<YearOfTax, List<TaxRate>>();    
        }

        public static RatesByYearsDictionary LoadDictionary()
        {
            return LoadTaxeRateDataByYear();
        }

        private static RatesByYearsDictionary LoadTaxeRateDataByYear()//Load taxes from DB for instance, or even from a API
        {
            var Years = new List<YearOfTax>()
            {
                // 2011
                new YearOfTax()
                {
                    Year = 2011
                     ,
                    Ceiling = (decimal)405.86
                },
                //2012
                new YearOfTax()
                {
                     Year = 2012
                    ,
                    Ceiling = (decimal)500.00
                }
            };
            var Rates = new List<List<TaxRate>>();
            //2011
            var rates = new List<TaxRate>()
            {
                new TaxRate()
                {
                    Min = (decimal)0
                    ,Max = (decimal)1106.90
                    ,Rate = (decimal)8
                },
                new TaxRate()
                {
                    Min = (decimal)1106.91
                    ,Max = (decimal)1844.83
                    ,Rate = (decimal)9
                },
                new TaxRate()
                {
                    Min = (decimal)1844.84
                    ,Max = (decimal)3689.66
                    ,Rate = (decimal)11
                },
            };
            //2012
            var rates2 = new List<TaxRate>()
            {
                new TaxRate()
                {
                    Min = (decimal)0
                    ,Max = (decimal)1000.00
                    ,Rate = (decimal)7
                },
                new TaxRate()
                {
                    Min = (decimal)1000.01
                    ,Max = (decimal)1500.00
                    ,Rate = (decimal)8
                },
                new TaxRate()
                {
                    Min = (decimal)1500.01
                    ,Max = (decimal)3000.00
                    ,Rate = (decimal)9
                },
                new TaxRate()
                {
                    Min = (decimal)3000.01
                    ,Max = (decimal)4000.00
                    ,Rate = (decimal)11
                },
            };

            var RatesByYear = new RatesByYearsDictionary();
            Rates.Add(rates);
            Rates.Add(rates2);

            RatesByYear.TaxLane.Add(Years[0], Rates[0]);
            RatesByYear.TaxLane.Add(Years[1], Rates[1]);

            return RatesByYear;
        }
    }
}
