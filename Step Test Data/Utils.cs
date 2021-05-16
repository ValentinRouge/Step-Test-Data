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
            /// retunr the list of X value associated with the step high
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
            ///Calculate the aerobic capacity
        {
            int number_of_points = Data.takenHr.Count();
            List<double> coeficient = new List<double>();
            for (int i = 0; i < number_of_points; i++)
            {
                for (int a = i + 1; a < number_of_points; a++)
                {
                    coeficient.Add((Data.takenHr[a] - Data.takenHr[i]) / (Data.takenX[a] - Data.takenX[i]));
                    ///calc all the coeficients bewteen all the points
                }
            }
            double average_coefficient = mathUtils.calcAverage(coeficient);
            ///calculate the average coefficient
            double averageX = mathUtils.calcAverage(Data.takenX);
            ///Calculate the average H 
            double averageY = mathUtils.calcAverage(Data.takenHr);
            ///Calculate the average HR
            double origin = averageY - averageX * average_coefficient;
            ///calculate the origin (to have the equation of the right)
            return (Data.maxHR - origin) / average_coefficient;
            /// return the aerobic capacity 
        }
        public Double getAerobicCapacity(CurrentTest Data, int valid, int invalid, int Xvalid )
            ///get the aerobic capacity when only one data is valid
        {
            List<int> list = new List<int> { valid, invalid }.ToList();
            ///Create a list with both HR values
            int max = list.Max();
            int min = list.Min();
            ///get the highest and lowest 
            int maxX = getY(Data, max);
            int minX = getY(Data, min);
            //get the associated X value

            double coeficient = (max - min) / (maxX - minX);
            ///Calculate the slope of the right

            double origin = valid - Xvalid * coeficient;
            ///get the origin of the right to have the equation
            return (Data.maxHR - origin) / coeficient;
        }

        public int getY(CurrentTest Data, int X)
            ///Search the Y value associates with one HR.
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
