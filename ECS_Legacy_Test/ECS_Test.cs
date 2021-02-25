using ECS_Legacy_version2;
using NUnit.Framework;
using NSubstitute;

namespace ECS_Legacy_Test
{
    public class ECS_Test
    {
        private ECS uut;
        private ITempSensor tempSensor;
        private IHeater heater;
        

        [SetUp]
        public void Setup()
        {
            tempSensor = Substitute.For<ITempSensor>();
            heater = Substitute.For<IHeater>();
            uut=new ECS(17,tempSensor,heater);
        }

        [TestCase(-5,-5)]
        [TestCase(0, 0)]
        [TestCase(2, 2)]
        [TestCase(10, 10)]
        [TestCase(17, 17)]
        [TestCase(24, 24)]
        [TestCase(35, 35)]
        [TestCase(45, 45)]
        public void Test_GetCurTemp(int temp, int expected)
        {
            tempSensor.GetTemp().Returns(temp);

            Assert.That(uut.GetCurTemp(),Is.EqualTo(expected));
        }

        [TestCase(-5)]
        [TestCase(16)]
        public void Test_Regulate_TempUnderThreshold_Expected_true(int temp)
        {
            tempSensor.GetTemp().Returns(temp);

            //tempSensor.Temp = temp;
            uut.Regulate();
          
            //Assert.That(heater.IsOn, Is.EqualTo(true));
            heater.Received(1).TurnOn();
        }


        [TestCase(17)]
        [TestCase(45)]
        public void Test_Regulate_TempOverThreshold_Expected_false(int temp)
        {
            tempSensor.GetTemp().Returns(temp);
            //tempSensor.Temp = temp;
            uut.Regulate();

            //Assert.That(heater.IsOn, Is.EqualTo(false));
            heater.Received().TurnOff();
        }

        [Test]
        public void Test_RunSelfTest_HeaterAndTempSensorIsCalled()
        {
            uut.RunSelfTest();

            //Assert.True(heater.SelfTestCalled);
            //Assert.That(tempSensor.SelfTestCalled);
        }

        [TestCase(22)]
        [TestCase(28)]
        public void Test_GetThresHold_IsEqualTo_SetThreshold(int threshold)
        {
            int thres = threshold;
            uut.SetThreshold(threshold);

            Assert.That(uut.GetThreshold(),Is.EqualTo(thres));

        }


        public class MockHeater : IHeater
        {
            public bool IsOn = false;
            public bool SelfTestCalled = false;
            public void TurnOff()
            {
                IsOn = false;
            }

            public void TurnOn()
            {
                IsOn = true;
            }

            public bool RunSelfTest()
            {
                SelfTestCalled = true;
                return SelfTestCalled;
            }
        }


    }
}