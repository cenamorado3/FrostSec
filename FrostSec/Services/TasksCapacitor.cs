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
                Name = "One"
            },
            new FrostTask
            {
                Name = "Two",
            },
            new FrostTask
            {
                Name = "Three",
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
                FrostTask movingTask = Tasks.Where(t => t.Name == task.Name).First();
                movingTask = task;
                NotifyStateChanged();
            }
        }

        public void AlterTask(FrostTask task, string state)
        {
            lock (_taskLock)
            {
                FrostTask movingTask = Tasks.Where(t => t.Name == task.Name).First();
                movingTask.State = state;
                movingTask = task;
                NotifyStateChanged();
            }
        }
    }
}
