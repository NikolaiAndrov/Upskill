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
                return "";
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

            return sb.ToString();
        }
    }
}
