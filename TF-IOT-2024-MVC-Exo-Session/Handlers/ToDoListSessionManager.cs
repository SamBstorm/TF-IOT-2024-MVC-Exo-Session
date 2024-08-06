
using System.Text.Json;

namespace TF_IOT_2024_MVC_Exo_Session.Handlers
{
    public class ToDoListSessionManager : SessionManager
    {
        public ToDoListSessionManager(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
        }

        public IEnumerable<string> ToDoList
        {
            get
            {
                if(_session.GetString(nameof(ToDoList)) is null) ToDoList = new List<string>();
                return JsonSerializer.Deserialize<IEnumerable<string>>(_session.GetString(nameof(ToDoList)));
            }
            set{
                _session.SetString(nameof(ToDoList), JsonSerializer.Serialize<IEnumerable<string>>(value));
            }
        }

        public void AddTask(string task)
        {
            List<string> tasks = ToDoList.ToList();
            if (tasks.Contains(task)) return;
            tasks.Add(task);
            ToDoList = tasks;
        }

        public void RemoveTask(string task) {
            List<string> tasks = ToDoList.ToList();
            if (!tasks.Contains(task)) return;
            tasks.Remove(task);
            ToDoList = tasks;
        }

        public void ClearTodoList()
        {
            ToDoList = new List<string>();
        }
    }
}
