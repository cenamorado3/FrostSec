namespace FrostSec.Data
{
    public class FrostTask
    {

        public string Name { get; set; }
        public List<string> States = new() { "ToDo", "Started", "Completed" };
        public string State { get; set; } = "ToDo";
        public string Style { get; set; } = "";
        public double X { get; set; }
        public double Y { get; set; }

        public void AdvanceState()
        {
            int nextStateIndex = States.IndexOf(State) + 1;
            if (nextStateIndex < States.Count)
            {
                string nextState = States[nextStateIndex];
                State = nextState;
                //X = 0;
                //Y = 0;
                Style = "";
            }
        }
    }
}
