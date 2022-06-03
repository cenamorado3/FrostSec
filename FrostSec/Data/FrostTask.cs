namespace FrostSec.Data
{
    public class FrostTask
    {

        public string Name { get; set; }
        public string State { get; set; } = "ToDo";
        public bool IsDragging { get; set; } = false;
    }
}
