using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    internal class TodoList
    {
        private ITodoListStorage storage;
        private List<TodoItem> _todos;

        public TodoList(ITodoListStorage storage)
        {
            this.storage = storage;
            _todos = new List<TodoItem>();
        }

        public bool AddTodo(TodoItem todoItem)
        {
            _todos.Add(todoItem);
            return storage.SaveTodos(_todos);

        }
        public void RemoveTodo(int index) 
        {
            _todos.RemoveAt(index);
        }
        public bool MarkTodoAsComplete(TodoItem todoItem)
        {
            todoItem.IsComplete = true;
            return storage.SaveTodos(_todos);
        }
        public List<TodoItem> GetTodos()
        {
            return _todos;
        }
        public List<TodoItem> ShowCompleteTodos()
        {
            return _todos.FindAll(todo => todo.IsComplete);
        }
        public List<TodoItem> ShowNotCompleteTodos()
        {
            return _todos.FindAll(todo => !todo.IsComplete);

        }
    }
}
