using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo;

namespace TodolistProgram
{
    internal class App
    {
        private readonly ITodoList todoList;
        private readonly IUserInteraction userInteraction;

        public App(
            ITodoList todoList,
            IUserInteraction userInteraction)
        {
            this.todoList = todoList;
            this.userInteraction = userInteraction;
        }
        internal void Start()
        {
            userInteraction.PrintChoiceMenu();

            bool runprogram = true;
            while (runprogram)
            {
                var choice = userInteraction.GetUserChoice();
                runprogram = ExecuteChoice(runprogram, choice, userInteraction, todoList);
            }
        }
        private static bool ExecuteChoice(bool runProgram, string choice, IUserInteraction ui, ITodoList todo)
        {
            switch (choice)
            {
                case "a":
                    var title = ui.GetStringInput("What needs to be done? ");
                    var description = ui.GetStringInput("Add a description, how/when? ");
                    todo.AddTodo(title, description);
                    break;
                case "m":
                    var index = ui.GetStringInput("Choose index to mark as complete");
                    var todoItem = todo.GetTodoItemByIndex(Convert.ToInt32(index));
                    todo.UpdateTodoStatusToComplete(todoItem);
                    break;
                case "n":
                    index = ui.GetStringInput("Choose index to mark as incomplete");
                    todoItem = todo.GetTodoItemByIndex(Convert.ToInt32(index));
                    todo.UpdateTodoStatusToInComplete(todoItem);
                    break;
                case "v":
                    var todos = todo.GetTodos();
                    ui.PrintTodoList(todos);
                    break;
                case "c":
                    var completeTodos = todo.GetCompleteTodos();
                    ui.PrintTodoList(completeTodos);
                    break;
                case "i":
                    var inCompleteTodos = todo.GetIncompleteTodos();
                    ui.PrintTodoList(inCompleteTodos);
                    break;
                case "r":
                    index = ui.GetStringInput("Choose index to remove. ");
                    todo.RemoveTodo(Convert.ToInt32(index));
                    break;
                default:
                    ui.DisplayMessage("Not a valid input");
                    break;
                case "x":
                    runProgram = false;
                    break;
            }
            return runProgram;
        }
    }
}