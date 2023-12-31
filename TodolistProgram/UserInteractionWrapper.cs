﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodolistProgram;

namespace Todo
{
    public class UserInteractionWrapper : IUserInteraction
    {
        private readonly IConsoleWrapper consoleWrapper;

        public UserInteractionWrapper(IConsoleWrapper consoleWrapper)
        {
            this.consoleWrapper = consoleWrapper;
        }
        public void DisplayMessage(string s)
        {
            consoleWrapper.WriteLine(s);
        }

        public string GetUserChoice()
        {
            var choice = Console.ReadLine();

            return choice.ToLower();
        }


        public void PrintChoiceMenu()
        {
            consoleWrapper.WriteLine($"""
                   ---------------
                   CHOOSE ACTION
                   ---------------
                   A - Add new task
                   R - Remove task
                   M - Mark as complete
                   N - Mark as incomplete
                   V - View all tasks
                   C - View complete tasks
                   I - View incomplete tasks

                   X - Exit
                   ---------------
                   """);
        }

        public void PrintTodoList(List<TodoItem> todoList)
        {
            int count = 0;
            Console.WriteLine("Index           Title           Description         Done");
            foreach (var todo in todoList)
            {
                Console.WriteLine($"{count}               {todo.Title}      {todo.Description}              {(todo.IsComplete ? "Done" : "Not Done")}");
                count++;
            }
        }
        public int GetIntInput(string prompt)
        {
            int value;

            consoleWrapper.WriteLine(prompt);

            while (!int.TryParse(consoleWrapper.ReadLine(), out value))
            {
                consoleWrapper.WriteLine("Incorrect input, please enter a valid integer.");
                consoleWrapper.WriteLine(prompt);
            }

            return value;
        }
        public string GetStringInput(string prompt)
        {
            string input = null;

            consoleWrapper.WriteLine(prompt);

            while (string.IsNullOrWhiteSpace(input))
            {
                input = consoleWrapper.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    consoleWrapper.WriteLine("Incorrect input, please try again");
                    consoleWrapper.WriteLine(prompt);
                }
            }
            return input;
        }
    }
}
