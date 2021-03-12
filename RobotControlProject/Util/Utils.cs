using System;
using System.Collections.Generic;
using RobotControlProject.Domain;

namespace RobotControlProject.Util
{
    public static class Utils
    {
        private static string Divider { get; } = "---------------------------------------------------------------------------------------";
        
        public static List<Robot> SortListByName(List<Robot> targetList)
        {
            var copyList = targetList;
            if (targetList.Count > 0)
            {
                copyList.Sort((x, y) => (x.Model).CompareTo(y.Model));
            }
            return copyList;
        }

        public static List<Robot> SortListByPrice(List<Robot> targetList)
        {
            var copyList = targetList;
            if (targetList.Count > 0)
            {
                copyList.Sort((x, y) => (x.Price).CompareTo(y.Price));
            }
            return copyList;
        }
        
        public static List<Robot> SortListByIndex(List<Robot> targetList)
        {
            var copyList = targetList;
            if (targetList.Count > 0)
            {
                copyList.Sort((x, y) => (y.Index).CompareTo(x.Index));
            }
            return copyList;
        }

        public static string RobotListToString(List<Robot> targetList)
        {
            var output = $"번호\tRobot id\t종류\tRobot 명\tx\ty\tprice\tdistance\tetc\t\r\n{Divider}\r\n";
            
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
            var copyRobotList = targetList;
            if (targetList.Count != 0)
            {
                SortListByIndex(copyRobotList);
                return copyRobotList[targetList.Count - 1].Index + 1;
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