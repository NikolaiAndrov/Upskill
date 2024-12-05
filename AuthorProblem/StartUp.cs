using AuthorProblem;

public class StartUp
{
    [Author("Niki")]
    private static void Main(string[] args)
    {
        Tracker tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}