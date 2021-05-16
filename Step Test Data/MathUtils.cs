using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_Test_Data
{
    class MathUtils
    {
        public double calcAverage(List<double> list)
        ///Calc a average value
        {
            int sum = 0;
            foreach (int val in list)
            {
                sum += val;
            }
            return sum / list.Count;
        }

        public double calcAverage(List<int> list)
            ///Calc a average value
        {
            int sum = 0;
            foreach (int val in list)
            {
                sum += val;
            }
            return sum / list.Count;
        }

        public int getClosestFrom(int d1, int d2, int d3, int d4, double l1, double l2)
        {
            List<int> values = new List<int> {d1, d2, d3, d4 }.ToList();
            List<double> gap = new List<double>();
            foreach (int value in values)
            {
                if (value < l1)
                {
                    gap.Add(l1 - value);
                } else
                {
                    gap.Add(value - l2);
                }
            }
            return values[gap.IndexOf(gap.Min())];
            //get the lowest value, get its index and return the value associated to this index

        }
    }
}
