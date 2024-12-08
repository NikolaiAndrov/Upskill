namespace CommandPattern.Core.Models
{
    using System;

    public class ExitCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);
            
            return null;
        }
    }
}
