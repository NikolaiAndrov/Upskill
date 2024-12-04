namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
            Console.WriteLine(new string('-', 55));
            string methods = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(methods);
        }
    }
}
