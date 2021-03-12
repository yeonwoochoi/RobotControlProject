using System;
using RobotControlProject.Util;
using RobotControlProject.Control;

namespace RobotControlProject.Main
{
    internal class Program
    {
        private static RobotController RobotController { get; } = RobotController.Instance;
        public static void Main(string[] args)
        {
            RobotController.Run();
        }
    }
}