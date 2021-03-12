namespace RobotControlProject.Domain
{
    public class DogRobot: Robot
    {
        private int BarkPower { get; }

        public string BarkStart()
        {
            return $"Bark Power {BarkPower}으로 짖기 시작했습니다.";
        }

        public string BarkDown()
        {
            return $"Bark Power {BarkPower}으로 짖다가 멈추었습니다.";
        }

        public override string ToString()
        {
            return $"{Index}\tDog Robot\t{Model}\t{X}\t{Y}\t{Price}\t{Distance}\tBark Power = {BarkPower}";
        }
        
        public DogRobot(int index, string name, int price, int x = 150, int y = 150, int distance = 10, int barkPower = 3): base(index, name, x, y, price, distance)
        {
            BarkPower = barkPower;
        }
    }
}