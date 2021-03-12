namespace RobotControlProject.Domain
{
    public class CleaningRobot: Robot
    {
        private int cleaningPower;


        public string CleaningStart()
        {
            return $"Cleaning Power {cleaningPower}으로 청소를 시작했습니다.";
        }

        public string CleaningDown()
        {
            return $"Cleaning Power {cleaningPower}으로 청소를 멈추었습니다.";
        }

        public override string ToString()
        {
            return $"{index}\tCleaning Robot\t{model}\t{x}\t{y}\t{price}\t{distance}\tCleaning Power = {cleaningPower}";
        }

        public CleaningRobot(string name, int x, int y, int price, int distance, int cleaningPower)
        {
            base.model = name;
            base.x = x;
            base.y = y;
            base.price = price;
            base.distance = distance;
            this.cleaningPower = cleaningPower;
        }
        
    }
}