using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    internal static class Data
    {
        public static string Path = @"C:\Users\LapStore\OneDrive\Рабочий стол\Sigma Camp\Homework12_Budzyn_S_I\clients.txt";
        public static List<string> Names = new List<string>() { "Mike", "Alex", "John", "Tom", "Jane", "Emma", "Nick", "Jack", "Scott", "Lizz", "Boris", "Joe", "Donald", "Ronald" };
        public const string _configFile = "appsettings.json";
        public const string _sectionName = "ClientInfoPath";
    }
}
