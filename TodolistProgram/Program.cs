using Todo;

namespace TodolistProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();
            var console = new ConsoleWrapper();
            var userInteraction = new UserInteractionWrapper(console);
            var todoList = new TodoList(storage);

            var app = new App(todoList, userInteraction);
            app.Start();
        }

        
    }
}