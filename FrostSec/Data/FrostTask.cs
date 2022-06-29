namespace FrostSec.Data
{
    public class FrostTask
    {
        public FrostTask()
        {
            Id = new Random().Next(1000, 2000);
            Comments.Insert(0, new() {Id=0,Message= "This is an example" });
        }

        public string Name { get; set; }
        public string State { get; set; } = "ToDo";
        public string ParentBoard { get; set; } = "Task";
        public string Description { get; set; } = @"
Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.

Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.

Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.

Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
";
        public bool IsDragging { get; set; } = false;
        public int Id { get; set; }
        public int Points { get; set; }
        public List<Comment> Comments { get; set; } = new();
    }
}
