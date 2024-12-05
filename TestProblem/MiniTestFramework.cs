namespace TestProblem
{
    using System.Reflection;

    public class MiniTestFramework
    {
        public void Execute(string className)
        {
            Type type = Type.GetType(className)!;

            if (type == null)
            {
                Console.WriteLine("Content not found!");
                return;
            }

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            var instance = Activator.CreateInstance(type);

            foreach (MethodInfo method in methods)
            {
                var attribute = method.GetCustomAttribute<MyTestAttribute>();

                if (attribute != null)
                {
                    method.Invoke(instance, new object[] { });
                }
            }
        }
    }
}
