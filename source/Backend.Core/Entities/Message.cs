namespace Backend.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Author { get; set; }
        public int Channel { get; set; }
        public DateTime Created { get; set; }
        public bool Edited { get; set; } = false;
    }
}
