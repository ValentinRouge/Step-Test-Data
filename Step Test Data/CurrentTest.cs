using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_Test_Data
{
    public class CurrentTest
    {
        public string Name { get; set;  }
        public int Age { get; set;  }
        public bool isFemale { get; set; }
        public StepHigh TestStepHigh { get; set; }
        public int HR1 { get; set; }
        public int HR2 { get; set; }
        public int HR3 { get; set; }
        public int HR4 { get; set; }
        public int HR5 { get; set; }
    }

    public enum StepHigh
    {
        _15 = 15, 
        _20 = 20, 
        _25 = 25, 
        _30 = 30
    }
}
