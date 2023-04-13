using System.Text.Json;
using NatsContracts.Models;
using System;

//ФИКСИТЬ НАМЕСПАСЕ ДОРАБАТЫВАТЬ ВСЁ

namespace NatsContracts
{
    public class Contract
    {
        public bool isTemperatureIncrease = false;
        public bool isTemperatureIncreasing = false;
        public Command? temperatureCommand;

        public void SetCommand(string jsonCommand)
        {
            // mapping jsonCommand to object
            Command? command;
            try
            {
                command = JsonSerializer.Deserialize<Command>(jsonCommand);
            }
            catch
            {
                //Console.WriteLine("[Contract] =>Json command parse error!");
                throw new Exception();
            }

            if (command == null)
            {
                //Console.WriteLine("[Contract] => Command is null!");
                throw new Exception();
            }

            // Select the required action
            switch (command.CommandName)
            {
                case "Increase temperature":
                    isTemperatureIncrease = true;
                    temperatureCommand = command;
                    break;
            }
        }
    }
}
