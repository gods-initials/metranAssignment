using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LongRunningTest
{
    public class TestThreeOut : Test
    {
        private Random rand;
        private int testDuration;
        private bool testSuccessful;
        private string error;
        private int param1;
        private bool param2;
        private string param3;
        public TestThreeOut()
        {
            param1 = 0;
            param2 = false;
            param3 = "";
            error = "";
            rand = new Random();
            testDuration = 10000 / 3;
        }
        private string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, rand.Next(1, 11)).Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public override void Run()
        {
            Thread.Sleep(testDuration);
            param1 = rand.Next();
            Thread.Sleep(testDuration);
            param2 = Convert.ToBoolean(rand.Next(2));
            Thread.Sleep(testDuration);
            param3 = RandomString();
            testSuccessful = Convert.ToBoolean(rand.Next(2));
            if (!testSuccessful)
            {
                switch (rand.Next(3))
                {
                    case 0:
                        error = "Изделие не найдено.";
                        break;
                    case 1:
                        error = "Некорректно заполнены параметры изделия.";
                        break;
                    case 2:
                        error = "Внутренняя ошибка.";
                        break;
                }
            }
        }
        public override Dictionary<string, string> ReturnResults()
        {
            return new Dictionary<string, string>
            {
                {"testSuccessful", testSuccessful.ToString()},
                {"error", error},
                {"param1", param1.ToString()},
                {"param2", param2.ToString()},
                {"param3", param3}
            };
        }
    }
}