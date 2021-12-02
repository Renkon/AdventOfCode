﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Problems
{
    public class Problem2 : IProblem<long, long>
    {

        public long DoPartA()
        {
            var horizontalAxis = 0;
            var verticalAxis = 0;

            var handlers = new Dictionary<string, Action<int>>
            {
                ["forward"] = (n) => horizontalAxis += n,
                ["down"] = (n) => verticalAxis += n,
                ["up"] = (n) => verticalAxis -= n,
            };

            return ProcessCommands(handlers, "2", ref horizontalAxis, ref verticalAxis);
        }

        public long DoPartB()
        {
            var aimValue = 0;
            var horizontalAxis = 0;
            var verticalAxis = 0;

            var handlers = new Dictionary<string, Action<int>>
            {
                ["forward"] = (n) =>
                {
                    horizontalAxis += n;
                    verticalAxis += aimValue * n;
                },
                ["down"] = (n) => aimValue += n,
                ["up"] = (n) => aimValue -= n,
            };

            return ProcessCommands(handlers, "2", ref horizontalAxis, ref verticalAxis);
        }

        private long ProcessCommands(
            IDictionary<string, Action<int>> commandHandlers,
            string inputName,
            ref int horizontalAxis,
            ref int verticalAxis)
        {
            var commands = Utils.InputToStringArray(inputName);

            foreach (var command in commands)
            {
                var (name, value) = GetCommandData(command);
                commandHandlers[name].Invoke(value);
            }

            return horizontalAxis * verticalAxis;
        }


        private (string, int) GetCommandData(string command)
        {
            var splitStr = command.Split(" ");
            return (splitStr[0], int.Parse(splitStr[1]));
        }
    }
}
