namespace People.Data.DTO
{
    public class GradeDTO : ObjectDTO
    {
       
        public int Value { get; set; }

        public int StudentId { get; set; }
        public virtual StudentDTO Student { get; set; }

        public int LectureId { get; set; }
        public virtual LectureDTO Lecture { get; set; }
    }
}
