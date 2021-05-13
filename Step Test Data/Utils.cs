using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_Test_Data
{
    class Utils
    {
        public double calcAverage(List<double> list)
        {
            int sum = 0;
            foreach (int val in list)
            {
                sum += val;
            }
            return sum / list.Count;
        }

        public double calcAverage(List<int> list)
        {
            int sum = 0;
            foreach (int val in list)
            {
                sum += val;
            }
            return sum / list.Count;
        }

        public void updateXList(CurrentTest Data)
        {
            switch (Data.TestStepHigh)
            {
                case StepHigh._15:
                    Data.Xvalues.AddRange(new[] { 11, 14, 18, 21, 25 }.ToList());
                    break;
                case StepHigh._20:
                    Data.Xvalues.AddRange(new[] { 12, 17, 21, 25, 29 }.ToList());
                    break;
                case StepHigh._25:
                    Data.Xvalues.AddRange(new[] { 14, 19, 24, 28, 33 }.ToList());
                    break;
                case StepHigh._30:
                    Data.Xvalues.AddRange(new[] { 16, 21, 27, 32, 37 }.ToList());
                    break;
            }
        }
    }
}
