namespace Backend.Core.Entities
{
    public class Conversation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FkAuthor { get; set; }
        public User? Author { get; set; }
        public int FkChannel { get; set; }
        public Channel? Channel { get; set; }
        public DateTime Created { get; set; }
    }
}
