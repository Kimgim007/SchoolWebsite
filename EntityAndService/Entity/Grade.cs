namespace People.EntityAndService.Entity
{
    public class Grade
    {
        public int ID { get; set; }
        public int Value { get; set; }   
        public Student Student { get; set; }
        public Lecture Lecture { get; set; }

        public Grade() { }
        public Grade(int Value, Student student ,Lecture lecture)
        {
            this.Value = Value;
            this.Student = student;
            this.Lecture = lecture;
        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}
