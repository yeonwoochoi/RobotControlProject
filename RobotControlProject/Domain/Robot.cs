namespace RobotControlProject.Domain
{
    public abstract class Robot
    {
        public int Index { get; }
        public string Model { get; }
        protected int X { get; private set; }
        protected int Y { get; private set; }
        protected int Distance { get; }
        public int Price { get; }

        protected Robot(int index, string model, int x, int y, int price, int distance = 5)
        {
            Index = index;
            Model = model;
            X = x;
            Y = y;
            Distance = distance;
            Price = price;
        }
        
        public int[] Move(int direction, int roomWidthSize, int roomVerticalSize)
        {
            var beforeMoveX = X;
            var beforeMoveY = Y;

            switch (direction)
            {
                case 1:
                    // Move toward top
                    if ( Y + Distance > roomVerticalSize )
                    {
                        Y = roomVerticalSize;
                    }
                    else
                    {
                        Y += Distance;
                    }
                    break;
                case 2:
                    // Move toward bottom
                    if (Y - Distance < 1)
                    {
                        Y = 1;
                    }
                    else
                    {
                        Y -= Distance;
                    }
                    break;
                case 3:
                    // Move toward left
                    if (X - Distance < 1)
                    {
                        X = 1;
                    }
                    else
                    {
                        X -= Distance;
                    }
                    break;
                case 4:
                    // Move toward right
                    if (X + Distance > roomWidthSize)
                    {
                        X = roomWidthSize;
                    }
                    else
                    {
                        X += Distance;
                    }
                    break;
                default:
                    break;
            }
            return new[] {beforeMoveX, beforeMoveY, X, Y};
        }

    }
}