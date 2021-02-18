using System;
using System.Collections.Generic;
using System.Text;
using ECS_Legacy_version2;

namespace ECS_Legacy_Test
{
    public class FakeTempSensor : ITempSensor
    {
        public int Temp { get; set; }
        public int GetTemp()
        {
            return Temp;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
