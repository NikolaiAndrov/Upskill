namespace AuthorProblem
{
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var currentType in types)
            {
                MethodInfo[] methods = currentType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic 
                    | BindingFlags.Instance | BindingFlags.Static);

                foreach (var method in methods)
                {
                    var attribute = method.GetCustomAttribute<AuthorAttribute>();

                    if (attribute != null)
                    {
                        Console.WriteLine($"{method.Name} is written by {attribute.Name}");
                    }
                }
            }
        }
    }
}
