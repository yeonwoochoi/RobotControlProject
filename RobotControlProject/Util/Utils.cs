using System;
using System.Collections.Generic;
using RobotControlProject.Domain;

namespace RobotControlProject.Util
{
    public static class Utils
    {
        
    
        private static string tabSpace = "    ";

        private static string divider =
            "---------------------------------------------------------------------------------------";
        
        public static List<Robot> SortListByName(List<Robot> targetList)
        {
            List<Robot> copyList = targetList;
            if (targetList.Count > 0)
            {
                copyList.Sort((x, y) => (x.model).CompareTo(y.model));
            }
            return copyList;
        }

        public static List<Robot> SortListByPrice(List<Robot> targetList)
        {
            List<Robot> copyList = targetList;
            if (targetList.Count > 0)
            {
                copyList.Sort((x, y) => (x.price).CompareTo(y.price));
            }
            return copyList;
        }
        
        public static List<Robot> SortListByIndex(List<Robot> targetList)
        {
            List<Robot> copyList = targetList;
            if (targetList.Count > 0)
            {
                copyList.Sort((x, y) => (y.index).CompareTo(x.index));
            }
            return copyList;
        }

        public static string RobotListToString(List<Robot> targetList)
        {
            string output = $"번호\tRobot id\t종류\tRobot 명\tx\ty\tprice\tdistance\tetc\t\r\n{divider}\r\n".Replace("\t", tabSpace);
            
            if (targetList.Count > 0)
            {
                for (var i = 0; i < targetList.Count; i++)
                {
                    output += $"{i + 1}\t{targetList[i].ToString()}\r\n";
                }
            }

            return output;
        }

        public static int CreateNewIndex(List<Robot> targetList)
        {
            List<Robot> copyRobotList = targetList;
            if (targetList.Count != 0)
            {
                SortListByIndex(copyRobotList);
                return copyRobotList[targetList.Count - 1].index + 1;
            }
            else
            {
                return 1;    
            }
        }

        public static int StringToInt(string input)
        {
            if (!int.TryParse(input.Trim(), out var output))
            {
                Console.WriteLine("Not a number");
            }
            
            return output;
        }
    }
}