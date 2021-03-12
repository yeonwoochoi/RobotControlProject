namespace RobotControlProject.Domain
{
    public class DogRobot: Robot
    {
        public int barkPower;

        public string BarkStart()
        {
            return $"Bark Power {barkPower}으로 짖기 시작했습니다.";
        }

        public string BarkDown()
        {
            return $"Bark Power {barkPower}으로 짖다가 멈추었습니다.";
        }

        public override string ToString()
        {
            return $"{index}\tDog Robot\t{model}\t{x}\t{y}\t{price}\t{distance}\tBark Power = {barkPower}";
        }
        
        public DogRobot(string name, int x, int y, int price, int distance, int barkPower)
        {
            base.model = name;
            base.x = x;
            base.y = y;
            base.price = price;
            base.distance = distance;
            this.barkPower = barkPower;
        }
    }
}