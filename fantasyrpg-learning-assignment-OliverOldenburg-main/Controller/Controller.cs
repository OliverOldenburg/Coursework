using System;
using System.Collections.Generic;
using CommandPattern;

namespace ControllerFeature
{
    public class Controller
    {
        private readonly Dictionary<ConsoleKey, ICommand> _keyCommandMap;

        public Controller()
        {
            _keyCommandMap = new Dictionary<ConsoleKey, ICommand>();
        }

        public void MapKeyToCommand(ConsoleKey key, ICommand command)
        {
            if (_keyCommandMap.ContainsKey(key))
            {
                _keyCommandMap[key] = command;
            }
            else
            {
                _keyCommandMap.Add(key, command);
            }
        }

        public void Listen()
        {
            Console.WriteLine("Controller is active. Press Q to quit.");

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    Console.WriteLine("Exiting controller...");
                    break;
                }

                if (_keyCommandMap.ContainsKey(key))
                {
                    _keyCommandMap[key].Execute();
                }
                else
                {
                    Console.WriteLine("No action mapped to this key.");
                }
            }
        }
    }
}
