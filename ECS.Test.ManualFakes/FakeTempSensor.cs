namespace ECS.Test.ManualFakes
{
    public class FakeTempSensor : ITempSensor
    {
        public int Temp { get; set; }
        public bool SelfTestResult { get; set; }

        public FakeTempSensor()
        {
            Temp = 0;
            SelfTestResult = true;
        }

        public int GetTemp()
        {
            return Temp;
        }
        public bool RunSelfTest()
        {
            return SelfTestResult;
        }
    }
}
