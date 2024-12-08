namespace CommandPattern.Core.Models
{
    using CommandPattern.Core.Contracts;
    using System;

    public class Engine : Contracts.IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string commandArgs = Console.ReadLine();
                    string result = this.commandInterpreter.Read(commandArgs);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Something went wrong, error message: {ex.Message}");
                }
            }
        }
    }
}
