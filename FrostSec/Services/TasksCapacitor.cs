using FrostSec.Data;

namespace FrostSec.Services
{
    public class TasksCapacitor
    {
        private object _taskLock = new object();
        public List<FrostTask> Tasks { get; set; } = new()
        {
            new FrostTask
            {
                Name = "As a user, I expect to be able to drag a task between states.",
                Points = 8
            },
            new FrostTask
            {
                Name = "As a user, I expect to be able to modify a task by clicking it.",
                Points = 5
            },
            new FrostTask
            {
                Name = "As a user, I expect to be able to share a task by url",
                Points = 3
            },
            new FrostTask
            {
                Name = "As a user, I expect message areas to be feature rich.",
                Points = 8
            },
        };

        public List<string> States { get; set; } = new() 
        { "ToDo", "Started", "Completed" };

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();


        /// <summary>
        /// Used by components which do not have direct access to the task.
        /// </summary>
        /// <param name="task"></param>
        public void SaveTaskChanges(FrostTask task)
        {
            lock (_taskLock)
            {
                FrostTask movingTask = Tasks.Where(t => t.Id == task.Id).First();
                movingTask = task;
                NotifyStateChanged();
            }
        }

        public void AlterTask(FrostTask task, string state)
        {
            lock (_taskLock)
            {
                FrostTask movingTask = Tasks.Where(t => t.Id == task.Id).First();
                movingTask.State = state;
                movingTask = task;
                NotifyStateChanged();
            }
        }
    }
}
