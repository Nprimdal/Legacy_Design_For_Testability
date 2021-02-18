namespace ECS_Legacy_version2
{
    public class Application
    {
        public static void Main(string[] args)
        {
            ITempSensor tempSensor = new TempSensor();
            IHeater heater = new Heater();

            var ecs = new ECS(28, tempSensor, heater);

            ecs.Regulate();

            ecs.SetThreshold(20);

            ecs.Regulate();
        }
    }
}
