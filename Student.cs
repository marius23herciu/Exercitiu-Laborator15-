using System;
using System.Collections.Generic;
using System.Text;

namespace Exercitiu_Laborator15_
{
    class Student
    {
        public Guid ID { get; private set; }
        public string FirstName { get;  set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public MajorType Major { get;  set; }
        public Student()
        {
            ID = Guid.NewGuid();
        }
        public enum MajorType
        {
            Informatics,
            Languages,
            Constructions
        }

        public override string ToString() =>
            $"{FirstName} {LastName}, age {Age}, majors in {Major}";
    }
}
