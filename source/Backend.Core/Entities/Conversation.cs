namespace Backend.Core.Entities
{
    public class Conversation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Author { get; set; }
        public int Channel { get; set; }
        public DateTime Created { get; set; }
    }
}
