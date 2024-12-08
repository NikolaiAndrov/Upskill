namespace TestProblem
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            MiniTestFramework miniTestFramework = new MiniTestFramework();
            miniTestFramework.Execute("TestProblem.ServiceTests");
        }
    }
}
