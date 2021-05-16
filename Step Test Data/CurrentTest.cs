using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_Test_Data
{
    public class CurrentTest
    {
        /// <summary>
        /// Class of test that are currently being done
        /// </summary>
        public string Name { get; set; }
        public int Age { get; set; }
        public bool isFemale { get; set; }
        public bool isMale { get; set; }
        //it is needed to have both to differenciate with the default false 
        public StepHigh TestStepHigh { get; set; }
        public int HR1 { get; set; }
        public int HR2 { get; set; }
        public int HR3 { get; set; }
        public int HR4 { get; set; }
        public int HR5 { get; set; }
        public int maxHR { get; set; }
        public double _85maxHR { get; set; }
        public double _50maxHR { get; set; }
        public List<int> takenHr { get; set; } = new List<int>();
        public List<int> takenX { get; set; } = new List<int>();
        // the taken list are the values that are correct (between 50% and 85%)
        public StepOfTheTest stepOfTheTest { get; set; } = StepOfTheTest.init;
        public string result_text { get; set; }
        //text display on the interface

        public List<int> Xvalues = new List<int>();
        public int aerobic_capacity { get; set; }
        public Rating FitnessResult { get; set; }

    }

    public enum StepHigh
    {
        /// <summary>
        /// All possible StepHigh
        /// </summary>
        _15 = 15, 
        _20 = 20, 
        _25 = 25, 
        _30 = 30
    }

    public enum StepOfTheTest
    {
        /// <summary>
        /// All possible step of the test
        /// </summary>
        init, 
        HR1,
        HR2, 
        HR3, 
        HR4, 
        finish
    }
}
