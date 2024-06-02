using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace с1_FamilyTree
{
    internal class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Person? Spouse { get; set; }
        public Person? Mother { get; set; }
        public Person? Father { get; set; }
        public List<Person> Children { get; set; }

        public Person(string fullName, int age, Gender gender) 
        {
            FullName = fullName;
            Age = age;
            Gender = gender;
            Children = new List<Person>();
        }
        
    }
    public enum Gender
    {
        Man,
        Woman
    }
}

