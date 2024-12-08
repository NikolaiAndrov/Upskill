namespace CommandPattern.Core.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : Contracts.ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] commandArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandArgs[0];
            string[] commandValue = commandArgs.Skip(1).ToArray();
            string commandClassName = $"{commandName}Command";

            Type type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name == commandClassName);

            if (type == null)
            {
                return "Command not found!";
            }

            MethodInfo method = type.GetMethod("Execute");

            if (method == null)
            {
                return "Method not found!";
            }

            var instance = Activator.CreateInstance(type);
            string result = method.Invoke(instance, new object[] {commandValue}).ToString();

            return result;
        }
    }
}
