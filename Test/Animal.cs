using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    interface  Animal
    {
        public string Name { get; set; }
        public string Sounds { get; set; }
        public string DoSounds()
        {   
            return Sounds;
        }
    }
    public class Fish : Animal
    {
        public string Name { get; set; }
        public string Sounds { get; set; }
        public Fish(string Name,string Sound)
        {
            this.Name = Name;
            this.Sounds = Sound;
        }
        public override string ToString()
        {
            return $"Это рыба - {Name}, и она издаёт звук {Sounds}";
        }
    }
    public class Rabbit : Animal
    {
        public string Name { get; set; }
        public string Sounds { get; set; }
        public Rabbit(string Name, string Sound)
        {
            this.Name = Name;
            this.Sounds = Sound;
        }
        public override string ToString()
        {
            return $"Это кролик - {Name}, и он издаёт звук {Sounds}";
        }
    }
    public class Tiger : Animal
    {
        public string Name { get; set; }
        public string Sounds { get; set; }
        public Tiger(string Name, string Sound)
        {
            this.Name = Name;
            this.Sounds = Sound;
        }
        public override string ToString()
        {
            return $"Это тигр - {Name}, и он издаёт звук {Sounds}";
        }
    }
    public class Dragon : Animal
    {
        public string Name { get; set; }
        public string Sounds { get; set; }
        public Dragon(string Name, string Sound)
        {
            this.Name = Name;
            this.Sounds = Sound;
        }
        public override string ToString()
        {
            return $"Это дракон - {Name}, и он издаёт звук {Sounds}";
        }
    }

}
