namespace TaskMaster.API.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Priority { get; set; } // "baixa", "média", "alta"
        public bool IsCompleted { get; set; }
    }
}
