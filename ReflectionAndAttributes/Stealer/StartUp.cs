namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string fields = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
                Console.WriteLine(fields);
                PrintHeader();
                string methods = spy.AnalyzeAccessModifiers("Stealer.Hacker");
                Console.WriteLine(methods);
                PrintHeader();
                string privateMethods = spy.RevealPrivateMethods("Stealer.Hacker");
                Console.WriteLine(privateMethods);
                PrintHeader();
                string gs = spy.CollectGettersAndSetters("Stealer.Hacker");
                Console.WriteLine(gs);
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong!");
            }
        }

        static void PrintHeader()
        {
            Console.WriteLine(new string('-', 55));
        }
    }
}
