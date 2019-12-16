using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactPro.classes
{
    class Numeric
    {
        public string test;

        public void dec1()
        {
            if (test == "")
            {
                test = "0.0";
            }
            test = String.Format("{0:0.0}", double.Parse(test));
        }
        public void dec2()
        {
            if (test == "")
            {
                test = "0.00";
            }
            test = String.Format("{0:0.00}", double.Parse(test));
        }
        public void dec3()
        {
            if (test == "")
            {
                test = "0.000";
            }
            test = String.Format("{0:0.000}", double.Parse(test));
        }
    }
}
