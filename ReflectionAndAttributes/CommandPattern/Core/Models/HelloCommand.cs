namespace CommandPattern.Core.Models
{
    using System;

    public class HelloCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello {args[0]}";
        }
    }
}
