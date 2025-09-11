using System.Collections.Generic;

namespace LongRunningTest
{
    public abstract class Test
    {
        private bool testSuccessful;
        private string error = "";
        private int testDuration;
        public abstract void Run();
        public abstract Dictionary<string, string> ReturnResults();
    }
}