using System.Collections.Generic;
using RobotControlProject.Domain;
using RobotControlProject.Util;

namespace RobotControlProject.Control
{
    public static class RobotControls
    {
        public static List<Robot> robotList;
        public static int roomWidthSize;
        public static int roomVerticalSize;

        static RobotControls()
        {
            robotList = new List<Robot>();
            roomWidthSize = 200;
            roomVerticalSize = 200;
        }

        public static bool InputRobotData(string type, string name, int x, int y, int price, int distance, int power)
        {
            switch (type)
            {
                case "c":
                {
                    CleaningRobot newCleaningRobot = new CleaningRobot(name, x, y, price, distance, power);
                    newCleaningRobot.index = Utils.CreateNewIndex(robotList);
                    robotList.Add(newCleaningRobot);
                    return true;
                }
                case "d":
                {
                    DogRobot newDogRobot = new DogRobot(name, x, y, price, distance, power);
                    newDogRobot.index = Utils.CreateNewIndex(robotList);
                    robotList.Add(newDogRobot);
                    return true;
                }
                default:
                    return false;
            }
        }
        
        public static string ShowAllRobotList(int sortType)
        {
            string output = $"<현재 로봇 {robotList.Count}대>\r\n";
            switch (sortType)
            {
                case 1:
                    return output += Utils.RobotListToString(Utils.SortListByName(robotList));
                case 2:
                    return output += Utils.RobotListToString(Utils.SortListByPrice(robotList));
                case 3:
                    return output += Utils.RobotListToString(Utils.SortListByIndex(robotList));
                default:
                    return null;
            }
        }

        public static string MoveIndividualRobot(int index, int direction)
        {
            Robot targetRobot = robotList.Find(x => x.index == index);
            if (targetRobot == null)
            {
                return "해당 로봇이 없습니다.";
            }
            int[] locationValues = targetRobot.Move(direction, roomWidthSize, roomVerticalSize);
            return $"{targetRobot.GetType()} 타입의 {targetRobot.model}가 {locationValues[0]} {locationValues[1]} 위치에서 {locationValues[2]} {locationValues[3]} 로 이동하였습니다.";
        }

        public static string DeleteIndividualRobot(int index)
        {
            Robot targetRobot = robotList.Find(x => x.index == index);
            if (targetRobot == null)
            {
                return "해당 로봇이 없습니다.";
            }

            robotList.Remove(targetRobot);
            return $"ID {index}번 로봇을 삭제하였습니다.";
        }

        public static string SearchByRobotPriceRange(int min, int max)
        {
            List<Robot> targetRobots = robotList.FindAll(x => x.price >= min && x.price <= max);
            return Utils.RobotListToString(targetRobots);
        }

        public static string SearchForRobotByIndex(int index)
        {
            List<Robot> targetRobots = robotList.FindAll(x => x.index == index);
            return Utils.RobotListToString(targetRobots);
        }
        
        public static string SearchForRobotByName(string name)
        {
            List<Robot> targetRobots = robotList.FindAll(x => x.model == name);
            return Utils.RobotListToString(targetRobots);
        }
    }
}