namespace backend.Data.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
