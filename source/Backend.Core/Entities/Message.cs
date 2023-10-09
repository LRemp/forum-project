namespace Backend.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int FkAuthor { get; set; }
        public int FkConversation { get; set; }
        public Conversation? Conversation { get; set; }
        public DateTime Created { get; set; }
        public bool Edited { get; set; } = false;
    }
}
