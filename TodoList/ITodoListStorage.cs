using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public interface ITodoListStorage
    {
        List<TodoItem> LoadTodos();
        bool SaveTodos(List<TodoItem> todos);
    }

}
