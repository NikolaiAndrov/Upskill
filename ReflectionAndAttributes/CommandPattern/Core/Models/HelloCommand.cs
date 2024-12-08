﻿namespace CommandPattern.Core.Models
{
    public class HelloCommand : Contracts.ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello {args[0]}";
        }
    }
}
