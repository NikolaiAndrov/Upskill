namespace TestProblem
{
    public class ServiceTests
    {
        [MyTest]
        public void ShouldPrintHelloWorldOnConsole()
        {
            Console.WriteLine("Hello World!");
        }

        [MyTest]
        public void ShouldPrintHelloOnConsole()
        {
            Console.WriteLine("Hello Friends!");
        }

        [MyTest]
        public void ShouldPrintProgrammingOnConsole()
        {
            Console.WriteLine("Programming!");
        }
    }
}
