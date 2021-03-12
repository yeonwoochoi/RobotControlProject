namespace RobotControlProject.Domain
{
    public class CleaningRobot: Robot
    {
        private int CleaningPower { get; }


        public string CleaningStart()
        {
            return $"Cleaning Power {CleaningPower}으로 청소를 시작했습니다.";
        }

        public string CleaningDown()
        {
            return $"Cleaning Power {CleaningPower}으로 청소를 멈추었습니다.";
        }

        public override string ToString()
        {
            return $"{Index}\tDog Robot\t{Model}\t{X}\t{Y}\t{Price}\t{Distance}\tCleaning Power = {CleaningPower}";
        }

        public CleaningRobot(int index, string name, int price, int x = 30, int y = 30, int distance = 3, int cleaningPower = 10): base (index, name, x, y, price, distance)
        {
            CleaningPower = cleaningPower;
        }
        
    }
}