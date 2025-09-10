namespace LongRunningTest;

public class TestThreeOut : Test
{
    private Random rand;
    private int testDuration;
    private bool testSuccessful;
    private int param1;
    private bool param2;
    private string param3;
    public TestThreeOut()
    {
        param1 = 0;
        param2 = false;
        param3 = "";
        rand = new Random();
        testDuration = 10000 / 3;
    }
    private string RandomString()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, rand.Next(1,11)).Select(s => s[rand.Next(s.Length)]).ToArray());
    }
    public override void Run()
    {
        testSuccessful = false;
        Thread.Sleep(testDuration);
        param1 = rand.Next();
        Thread.Sleep(testDuration);
        param2 = Convert.ToBoolean(rand.Next(2));
        Thread.Sleep(testDuration);
        param3 = RandomString();
        testSuccessful = true;
    }
    public override Dictionary<string, string> ReturnResults()
    {
        return new Dictionary<string, string>
        {
            {"param1", param1.ToString()},
            {"param2", param2.ToString()},
            {"param3", param3}
        };
    }
}