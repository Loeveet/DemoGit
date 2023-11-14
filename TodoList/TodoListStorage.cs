using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class TodoListStorage : ITodoListStorage
    {
        public List<TodoItem> LoadTodos()
        {
            throw new NotImplementedException();
        }

        public bool SaveTodos(List<TodoItem> todos)
        {
            throw new NotImplementedException();
        }
    }
}
