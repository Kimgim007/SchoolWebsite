using System;
namespace People.EntityAndService.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }       
        public Person() { }
        //ОПТИМИЗИРОВАТЬ КОД БЕЗ ПОВТОРЕНИЯ!!!
        public Person(string name, DateTime Birthday, string gender)
        {
            this.Name = name;
            this.Birthday = Birthday;
            switch (gender)
            {
                case "м":
                case "male": { this.Gender = Gender.male; break; }
                case "f":
                case "female": { this.Gender = Gender.female; break; }


                default: { this.Gender = Gender.male; break; }
            }
        }
        public Person(string name, string Birthday, string gender)
        {
            this.Name = name;
            this.Birthday = DateTime.Parse(Birthday);
            switch (gender)
            {
                case "m":
                case "male": { this.Gender = Gender.male; break; }
                case "f":
                case "female": { this.Gender = Gender.female; break;}          
               
                default: { this.Gender = Gender.female; break; }
            }
        }
        public Person(string name, DateTime Birthday, int gender)
        {
            this.Name = name;
            this.Birthday = Birthday;
            this.Gender = (Gender)gender;
        }
        public int Age()
        {
            int age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.Month < Birthday.Month)
            {
                age--;
            }
            if (DateTime.Now.Month == Birthday.Month)
            {
                if (DateTime.Now.Day < Birthday.Day)
                {
                    age--;
                }
            }
            return age;
        }    
    }
}
