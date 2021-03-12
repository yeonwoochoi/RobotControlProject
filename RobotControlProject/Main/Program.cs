using System;
using RobotControlProject.Util;
using RobotControlProject.Control;

namespace RobotControlProject.Main
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool endApp = false;
            string options = "1. 로봇 데이터 입력\r\n2. 로봇 리스트 보기\r\n3. 개별 Robot 이동\r\n4. 로봇 삭제\r\n5. 로봇 가격 범위로 검색\r\n6. 로봇 검색\r\n7. 종료\r\n입력: ";
            
            while (!endApp)
            {
                string type;
                
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
                        InputRobotDataInConsole();
                        break;
                    case "2":
                        ShowAllRobotListInConsole();
                        break;
                    case "3":
                        MoveIndividualRobotConsole();
                        break;
                    case "4":
                        DeleteIndividualRobotConsole();
                        break;
                    case "5":
                        SearchByRobotPriceRangeConsole();
                        break;
                    case "6":
                        SearchForRobotConsole();
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

        private static void InputRobotDataInConsole()
        {
            bool endFunction = false;
            
            while (!endFunction)
            {
                string robotName;
                int robotXposition;
                int robotYposition;
                int robotPrice;
                int robotDistance;
                int robotPower;
                
                //Input robot type and Check if input value is valid.
                Console.WriteLine("제품 종류를 입력하세요(c: CleaningRobot, d: DogRobot, x: 홈으로): ");
                
                string robotType = Console.ReadLine();

                if (robotType == "x")
                {
                    endFunction = true;
                    continue;
                }
                
                if (robotType != "c" && robotType != "d")
                {
                    Console.WriteLine("c, d 값만 받습니다.");
                    continue;
                }
                
                //Input specific robot name data
                Console.WriteLine("Name : ");
                robotName = Console.ReadLine();
                
                //Input specific robot x position data
                Console.WriteLine("X position : ");
                robotXposition = Utils.StringToInt(Console.ReadLine());
                if (robotXposition < 1 || robotXposition > RobotControls.roomWidthSize)
                {
                    Console.WriteLine($"Initial X Position 은 1 이상 {RobotControls.roomWidthSize} 이하 값이여야 합니다.");
                    continue;
                }

                //Input specific robot y position data
                Console.WriteLine("Y position : ");
                robotYposition = Utils.StringToInt(Console.ReadLine());
                if (robotYposition < 1 || robotYposition > RobotControls.roomVerticalSize)
                {
                    Console.WriteLine($"Initial Y Position 은 1 이상 {RobotControls.roomVerticalSize} 이하 값이여야 합니다.");
                    continue;
                }
                
                //Input specific robot price data
                Console.WriteLine("Price : ");
                robotPrice = Utils.StringToInt(Console.ReadLine());
                
                
                //Input specific robot distance data
                Console.WriteLine("Distance : ");
                robotDistance = Utils.StringToInt(Console.ReadLine());

                
                //Input specific robot power data
                switch (robotType)
                {
                    case "c":
                        Console.WriteLine("Cleaning Power : ");
                        robotPower = Utils.StringToInt(Console.ReadLine());
                        break;
                    case "d":
                        Console.WriteLine("Bark Power : ");
                        robotPower = Utils.StringToInt(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Wrong robot type.");
                        continue;
                }

                
                //Create Robot Instance
                if (RobotControls.InputRobotData(robotType, robotName, robotXposition, robotYposition,
                    robotPrice, robotDistance, robotPower))
                {
                    Console.WriteLine("제품이 성공적으로 저장되었습니다.");
                    endFunction = true;
                }
                else
                {
                    Console.WriteLine("제품 생성 도중 오류가 발생했습니다. 다시 입력해 주십시오.");
                }
            }
        }

        private static void ShowAllRobotListInConsole()
        {
            Console.WriteLine("로봇 리스트 정렬을 선택하세요(1. 로봇명순, 2. 가격순 3. ID순) : ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine(RobotControls.ShowAllRobotList(1));
                    break;
                case "2":
                    Console.WriteLine(RobotControls.ShowAllRobotList(2));
                    break;
                case "3":
                    Console.WriteLine(RobotControls.ShowAllRobotList(3));
                    break;
                default:
                    Console.WriteLine("1, 2, 3 중 하나의 값을 입력하시오.");
                    break;
            }
        }

        private static void MoveIndividualRobotConsole()
        {
            Console.WriteLine("이동할 로봇의 ID를 선택하세요: ");
            int id = Utils.StringToInt( Console.ReadLine());
            
            Console.WriteLine("이동 (1. 상, 2. 하, 3. 좌, 4. 우) : ");
            string direction = Console.ReadLine();

            switch (direction)
            {
                case "1":
                    Console.WriteLine(RobotControls.MoveIndividualRobot(id, 1));
                    break;
                case "2":
                    Console.WriteLine(RobotControls.MoveIndividualRobot(id, 2));
                    break;
                case "3":
                    Console.WriteLine(RobotControls.MoveIndividualRobot(id, 3));
                    break;
                case "4":
                    Console.WriteLine(RobotControls.MoveIndividualRobot(id, 4));
                    break;
                default:
                    Console.WriteLine("1, 2, 3, 4 중 하나의 값을 입력하시오.");
                    break;
            }
        }

        private static void DeleteIndividualRobotConsole()
        {
            Console.WriteLine("삭제할 로봇의 ID를 입력하세요: ");
            int index = Utils.StringToInt(Console.ReadLine());
            Console.WriteLine(RobotControls.DeleteIndividualRobot(index));
        }

        private static void SearchByRobotPriceRangeConsole()
        {
            Console.WriteLine("가격의 범위를 입력하세요: ");
            
            Console.WriteLine("최솟값 : ");
            int min = Utils.StringToInt(Console.ReadLine());
            
            Console.WriteLine("최댓값 : ");
            int max = Utils.StringToInt(Console.ReadLine());
            
            Console.WriteLine(RobotControls.SearchByRobotPriceRange(min, max));
        }

        private static void SearchForRobotConsole()
        {
            Console.WriteLine("검색 조건을 고르세요 (1. 이름, 2. id) : ");
            string searchNumber = Console.ReadLine();
            string input;

            switch (searchNumber)
            {
                case "1":
                    Console.WriteLine("로봇의 이름을 입력해 주세요: ");
                    input = Console.ReadLine();
                    Console.WriteLine(RobotControls.SearchForRobotByName(input));
                    break;
                case "2":
                    Console.WriteLine("로봇의 ID를 입력해 주세요: ");
                    input = Console.ReadLine();
                    Console.WriteLine(RobotControls.SearchForRobotByIndex(Utils.StringToInt(input)));
                    break;
                default:
                    Console.WriteLine("1, 2 중 하나의 값을 입력하시오.");
                    break;
            }
        }
    }
}