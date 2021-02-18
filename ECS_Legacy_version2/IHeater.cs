using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Legacy_version2
{
    public interface IHeater
    {
        void TurnOff();
        void TurnOn();
        bool RunSelfTest();
    }
}
