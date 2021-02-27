using NSubstitute;
using NUnit.Framework;

namespace ECS.Test.ManualFakes
{
    [TestFixture]
    public class ECSNSubstituteTest
    {
        private IHeater _heater;
        private ITempSensor _tempSensor;
        private ECS _uut;

        [SetUp]
        public void Setup()
        {
            //Opretter fakes, der kan anvendes som både stub og mock
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();

            //Opretter ny unit-under-test af type ECS
            _uut = new ECS(_tempSensor, _heater, 16);
        }

        //Opretter tests
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void RunSelfTest_SelfTestFails_TempOrHeaterIsFalse(bool temp, bool heater)
        {
            _tempSensor.RunSelfTest().Returns(temp);
            _heater.RunSelfTest().Returns(heater);
            Assert.IsFalse(_uut.RunSelfTest());
        }

        [TestCase(true, true)]
        public void RunSelfTest_SelfTestPass_TempOrHeaterIsTrue(bool temp, bool heater)
        {
            _tempSensor.RunSelfTest().Returns(temp);
            _heater.RunSelfTest().Returns(heater);
            Assert.IsTrue(_uut.RunSelfTest());
        }

        [Test]
        public void Regulate_TempBelowThreshold_HeaterTurnOn()
        {
            _tempSensor.GetTemp().Returns(13);
            _uut.Regulate();
            _heater.Received(1).TurnOn();
        }

        [Test]
        public void Regulate_TempAboveThreshold_HeaterTurnOff()
        {
            _tempSensor.GetTemp().Returns(17);
            _uut.Regulate();
            _heater.Received(1).TurnOff();
        }



    }
}