namespace Entities
{
    public class Note
    {
        private int id;
        private DateTime created;
        private string title;
        private string text;

        public Note(int id, DateTime created, string title, string text)
        {
            Id = id;
            Created = created;
            Title = title;
            Text = text;
        }

        public Note(DateTime created, string title, string text) 
            :this(0, created, title, text)
        {
           // leave empty
        }

        public int Id { get => id; set => id = value; }
        public DateTime Created { get => created; set => created = value; }
        public string Title { get => title; set => title = value; }
        public string Text { get => text; set => text = value; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}