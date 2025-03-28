namespace MementoPattern
{
    // Originator
    public class Editor
    {
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        public EditorState CreateState()
        {
            return new EditorState(this.Title, this.Content);
        }

        public void Restore(EditorState state)
        {
            this.Title = state.GetTitle();
            this.Content = state.GetContent();
        }
    }
}
