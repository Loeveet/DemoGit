using System;
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

        public string GetInput(string instruction)
        {
            consoleWrapper.WriteLine($"{instruction}");

            var input = consoleWrapper.ReadLine();

            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException("...");

            return input;
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
    }
}
