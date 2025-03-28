namespace MementoPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor();
            History history = new History(editor);
            history.Backup();
            Console.WriteLine(history.ShowHistory());

            editor.Title = "Test";
            editor.Content = "Testing Functionality";
            history.Backup();
            Console.WriteLine(history.ShowHistory());

            history.Undo();
            Console.WriteLine(history.ShowHistory());
        }
    }
}
