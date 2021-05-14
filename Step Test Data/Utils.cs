using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_Test_Data
{
    class Utils
    {
        MathUtils mathUtils = new MathUtils();

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

        public Double getAerobicCapacity(CurrentTest Data)
        {
            int number_of_points = Data.takenHr.Count();
            List<double> coeficient = new List<double>();
            for (int i = 0; i < number_of_points; i++)
            {
                for (int a = i + 1; a < number_of_points; a++)
                {
                    coeficient.Add((Data.takenHr[a] - Data.takenHr[i]) / (Data.takenX[a] - Data.takenX[i]));
                }
            }
            double average_coefficient = mathUtils.calcAverage(coeficient);
            double averageX = mathUtils.calcAverage(Data.takenX);
            double averageY = mathUtils.calcAverage(Data.takenHr);
            double origin = averageY - averageX * average_coefficient;
            return (Data.maxHR - origin) / average_coefficient;
        }
        public Double getAerobicCapacity(CurrentTest Data, int valid, int invalid, int Xvalid )
        {
            List<int> list = new List<int> { valid, invalid }.ToList();
            int max = list.Max();
            int min = list.Min();
            int maxY = getY(Data, max);
            int minY = getY(Data, min);

            double coeficient = (max - min) / (maxY - minY);

            double origin = valid - Xvalid * coeficient;
            return (Data.maxHR - origin) / coeficient;
        }

        public int getY(CurrentTest Data, int X)
        {
            if (X == Data.HR1)
            {
                return Data.Xvalues[0];
            } else if (X == Data.HR2)
            {
                return Data.Xvalues[1];
            } else if (X == Data.HR3)
            {
                return Data.Xvalues[2];
            } else if (X == Data.HR4)
            {
                return Data.Xvalues[3];
            } else
            {
                return Data.Xvalues[4];
            }
        }
    }
}
