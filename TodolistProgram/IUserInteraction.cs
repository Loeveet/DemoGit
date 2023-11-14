using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public interface IUserInteraction
    {
        public string GetUserChoice();
        public string GetStringInput(string s);
        public int GetIntInput(string s);
        public void DisplayMessage(string s);
        void PrintChoiceMenu();
        void PrintTodoList(List<TodoItem> todos);
    }
}
