using System;
using System.Collections.Generic;
using RobotControlProject.Domain;
using RobotControlProject.Util;

namespace RobotControlProject.Control
{
    public class RobotController
    {
        private List<Robot> RobotList { get; } = new List<Robot>();
        public int RoomWidthSize { get; } = 200;
        public int RoomVerticalSize { get; } = 200;

        private ConsoleUtils ConsoleUtils { get; } = new ConsoleUtils();
        
        // Singleton code
        private RobotController() {}
        
        private static RobotController _instance = null;

        public static RobotController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RobotController();
                }
                return _instance;
            }
        }

        
        public bool InputRobotData(string type, string name, int x, int y, int price, int distance, int power)
        {
            switch (type)
            {
                case "c":
                
                    var newCleaningRobot = new CleaningRobot(Utils.CreateNewIndex(RobotList), name, price, x, y, distance, power);
                    RobotList.Add(newCleaningRobot);
                    return true;
                
                case "d":
                
                    var newDogRobot = new DogRobot(Utils.CreateNewIndex(RobotList), name, price, x, y, distance, power);
                    RobotList.Add(newDogRobot);
                    return true;
                
                default:
                    return false;
            }
        }
        
        public string ShowAllRobotList(int sortType)
        {
            var output = $"<현재 로봇 {RobotList.Count}대>\r\n";
            switch (sortType)
            {
                case 1:
                    return output += Utils.RobotListToString(Utils.SortListByName(RobotList));
                case 2:
                    return output += Utils.RobotListToString(Utils.SortListByPrice(RobotList));
                case 3:
                    return output += Utils.RobotListToString(Utils.SortListByIndex(RobotList));
                default:
                    return null;
            }
        }

        public string MoveIndividualRobot(int index, int direction)
        {
            var targetRobot = RobotList.Find(x => x.Index == index);
            if (targetRobot == null)
            {
                return "해당 로봇이 없습니다.";
            }
            var locationValues = targetRobot.Move(direction, RoomWidthSize, RoomVerticalSize);
            return $"{targetRobot.GetType()} 타입의 {targetRobot.Model}가 {locationValues[0]} {locationValues[1]} 위치에서 {locationValues[2]} {locationValues[3]} 로 이동하였습니다.";
        }

        public string DeleteIndividualRobot(int index)
        {
            var targetRobot = RobotList.Find(x => x.Index == index);
            if (targetRobot == null)
            {
                return "해당 로봇이 없습니다.";
            }

            RobotList.Remove(targetRobot);
            return $"ID {index}번 로봇을 삭제하였습니다.";
        }

        public string SearchByRobotPriceRange(int min, int max)
        {
            var targetRobots = RobotList.FindAll(x => x.Price >= min && x.Price <= max);
            return Utils.RobotListToString(targetRobots);
        }

        public string SearchForRobotByIndex(int index)
        {
            var targetRobots = RobotList.FindAll(x => x.Index == index);
            return Utils.RobotListToString(targetRobots);
        }
        
        public string SearchForRobotByName(string name)
        {
            var targetRobots = RobotList.FindAll(x => x.Model == name);
            return Utils.RobotListToString(targetRobots);
        }

        public void Run()
        {
            var endApp = false;
            var options = "1. 로봇 데이터 입력\r\n2. 로봇 리스트 보기\r\n3. 개별 Robot 이동\r\n4. 로봇 삭제\r\n5. 로봇 가격 범위로 검색\r\n6. 로봇 검색\r\n7. 종료\r\n입력: ";
            
            while (!endApp)
            {
                var type = "";
                
                //Choose options in this console app
                try
                {
                    Console.WriteLine(options);
                    type = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong type. Please input 1 ~ 7.");
                    continue;
                }
                
                //Perform the function corresponding to the entered option
                switch (type)
                {
                    case "1":
                        ConsoleUtils.InputRobotDataInConsole();
                        break;
                    case "2":
                        ConsoleUtils.ShowAllRobotListInConsole();
                        break;
                    case "3":
                        ConsoleUtils.MoveIndividualRobotConsole();
                        break;
                    case "4":
                        ConsoleUtils.DeleteIndividualRobotConsole();
                        break;
                    case "5":
                        ConsoleUtils.SearchByRobotPriceRangeConsole();
                        break;
                    case "6":
                        ConsoleUtils.SearchForRobotConsole();
                        break;
                    case "7":
                        endApp = true;
                        break;
                    default:
                        break;
                }
                
            }
            return;
        }
    }
}