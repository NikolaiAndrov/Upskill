namespace Stealer
{
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsName)
        {
            Type type = Type.GetType(className)!;

            if (type == null )
            {
                return "Content not found!";
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {type.FullName}");

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);  

            object instance = Activator.CreateInstance(type, new object[] { })!;

            foreach (var field in fields)
            {
                if (fieldsName.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(instance)}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className)!;

            if (type == null)
            {
                return "Content not found!";
            }

            StringBuilder sb = new StringBuilder();

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            foreach (var field in fields)
            {
                if (field.IsPublic)
                {
                    sb.AppendLine($"{field.Name} must be private!");
                }
            }

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.IsPrivate && method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }
                else if (method.IsPublic && method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className)!;

            if(type == null)
            {
                return "Content not found!";
            }

            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType!.Name}");

            foreach (var method in methods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
