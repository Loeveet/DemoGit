using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public interface ITodoList
    {
        TodoItem AddTodo(string title, string description);
        List<TodoItem> GetCompleteTodos();
        List<TodoItem> GetIncompleteTodos();
        TodoItem GetTodoItemByIndex(int v);
        List<TodoItem> GetTodos();
        void RemoveTodo(int v);
        TodoItem UpdateTodoStatusToComplete(TodoItem todoItem);
        TodoItem UpdateTodoStatusToInComplete(TodoItem todoItem);
    }
}
