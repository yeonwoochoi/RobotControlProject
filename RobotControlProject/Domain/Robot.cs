namespace RobotControlProject.Domain
{
    public abstract class Robot
    {
        public int index = -1;
        public string model;
        public int x;
        public int y;
        public int distance;
        public int price;

        public abstract string ToString();

        public int[] Move(int direction, int roomWidthSize, int roomVerticalSize)
        {
            int beforeMoveX = x;
            int beforeMoveY = y;

            switch (direction)
            {
                case 1:
                    // Move toward top
                    if ( y + distance > roomVerticalSize )
                    {
                        y = roomVerticalSize;
                    }
                    else
                    {
                        y += distance;
                    }
                    break;
                case 2:
                    // Move toward bottom
                    if (y - distance < 1)
                    {
                        y = 1;
                    }
                    else
                    {
                        y -= distance;
                    }
                    break;
                case 3:
                    // Move toward left
                    if (x - distance < 1)
                    {
                        x = 1;
                    }
                    else
                    {
                        x -= distance;
                    }
                    break;
                case 4:
                    // Move toward right
                    if (x + distance > roomWidthSize)
                    {
                        x = roomWidthSize;
                    }
                    else
                    {
                        x += distance;
                    }
                    break;
                default:
                    break;
            }
            return new[] {beforeMoveX, beforeMoveY, x, y};
        }

    }
}