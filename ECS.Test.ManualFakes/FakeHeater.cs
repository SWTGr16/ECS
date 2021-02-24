namespace ECS.Test.ManualFakes
{
    public class FakeHeater : IHeater
    {
        public int TurnOffCalledTimes { get; set; }
        public int TurnOnCalledTimes { get; set; }
        public bool SelfTestResult { get; set; }

        public FakeHeater()
        {
            TurnOffCalledTimes = 0;
            TurnOnCalledTimes = 0;
            SelfTestResult = true;
        }

        public void TurnOn()
        {
            ++TurnOnCalledTimes;
        }

        public void TurnOff()
        {
            ++TurnOffCalledTimes;
        }

        public bool RunSelfTest()
        {
            return SelfTestResult;
        }
    }
}