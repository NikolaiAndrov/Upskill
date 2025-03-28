namespace MementoPattern
{
    // Memento
    public class EditorState
    {
        private readonly string title;
        private readonly string content;
        private readonly DateTime timestamp;

        public EditorState(string title, string content)
        {
            this.title = title;
            this.content = content;
            this.timestamp = DateTime.Now;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public string GetContent()
        {
            return this.content;
        }

        public DateTime GetTimestamp()
        {
            return this.timestamp;
        }
    }
}
