using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LongRunningTest
{
    public class TestOneOut : Test
    {
        private Random rand;
        private int testDuration;
        private bool testSuccessful;
        private string error;
        private float param1;
        public TestOneOut()
        {
            param1 = 0;
            error = "";
            rand = new Random();
            testDuration = 1000;
        }
        public override void Run()
        {
            Thread.Sleep(testDuration);
            param1 = rand.Next();
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
                { "param1", param1.ToString()}
            };
        }
    }
}