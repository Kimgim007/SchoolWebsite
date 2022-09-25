namespace People.EntityAndService.Entity
{
    public class Subject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Subject() { }
        public Subject(string Title)
        {
            this.Title = Title;
        }
        public override string ToString()
        {
            return Title;
        }
    }
}
