namespace MementoPattern
{
    using System.Text;

    // Caretaker
    public class History
    {
        private Stack<EditorState> states;
        private Editor editor;

        public History(Editor editor)
        {
            this.editor = editor;
            this.states = new Stack<EditorState>();
        }

        public void Backup()
        {
            this.states.Push(this.editor.CreateState());
        }

        public void Undo()
        {
            if(this.states.Count == 0)
            {
                return;
            }

            EditorState state = this.states.Pop();
            this.editor.Restore(state);
        }

        public string ShowHistory()
        {
            StringBuilder sb = new StringBuilder();

            foreach (EditorState state in this.states)
            {
                sb.AppendLine(state.ToString());
            }

            return sb.ToString();
        }
    }
}
