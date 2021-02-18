using ECS_Legacy_version2;
using NUnit.Framework;

namespace ECS_Legacy_Test
{
    public class ECS_Test
    {


        [SetUp]
        public void Setup()
        {
            
        }

        [TestCase(-5,-5)]
        [TestCase(0, 0)]
        [TestCase(2, 2)]
        [TestCase(10, 10)]
        [TestCase(17, 17)]
        [TestCase(24, 24)]
        [TestCase(35, 35)]
        [TestCase(45, 45)]
        public void Test_GetTemp_ExpectedEqualsProperty()
        {

        }

        

    }
}