namespace backend.Data.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
