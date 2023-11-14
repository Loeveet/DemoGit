using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public class TodoList : ITodoList
    {
        private readonly IStorage _todoListStorage;

        public TodoList(IStorage todoListStorage)
        {
            _todoListStorage = todoListStorage;
        }

        public List<TodoItem> GetTodos() => _todoListStorage.GetAllTodos();

        public List<TodoItem> GetCompleteTodos()
        {
            var allTodos = _todoListStorage.GetAllTodos();

            return allTodos.Where(x => x.IsComplete == true).ToList();
        }

        public TodoItem GetTodoItemByIndex(int index)
        {
            var allTodos = _todoListStorage.GetAllTodos();
            if (allTodos.Count < index + 1)
                throw new InvalidOperationException("The index doesn't exist");

            return allTodos[index];
        }

        public List<TodoItem> GetIncompleteTodos()
        {
            var allTodos = _todoListStorage.GetAllTodos();

            return allTodos.Where(x => x.IsComplete == false).ToList();
        }

        public TodoItem AddTodo(string title, string description)
        {
            var todoItem = new TodoItem
            {
                Title = title,
                Description = description
            };

            _todoListStorage.SaveTodoItem(todoItem);

            return todoItem;
        }

        public TodoItem UpdateTodoStatusToComplete(TodoItem todoItem)
        {
            todoItem.IsComplete = true;

            _todoListStorage.SaveTodoItem(todoItem);

            return todoItem;
        }

        public TodoItem UpdateTodoStatusToInComplete(TodoItem todoItem)
        {
            todoItem.IsComplete = false;

            _todoListStorage.SaveTodoItem(todoItem);

            return todoItem;
        }

        public void RemoveTodo(int index) => _todoListStorage.RemoveTodoItem(index);


    }
}
