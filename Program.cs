using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercitiu_Laborator15_
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Exercitii
• Un student este caracterizat de
• Id (unic)
• Nume
• Prenume
• Varsta
• Specializare
• Specializarile vor fi
• Informatica
• Litere
• Constructii
• Initializati si populati o lista de
student si scrieti query-urile de
mai jos
             */
            var students = GetStudents;
            /*
             Exercitii
1. Afisati cel mai in varsta student de la
Informatica*/
            var infoStudents = students.Where(s => s.Major == Student.MajorType.Informatics);
            //sau
            //var infoStudents = from student in students
            //                   where student.Major == Student.Majors.Informatics
            //                   select student;
            var oldestInformaticsStudent = infoStudents.Where(s => s.Age == infoStudents.Max(s => s.Age));
            foreach (var student in oldestInformaticsStudent)
            {
                Console.WriteLine($"Oldest informatics student is {student}");
            }
            /*
/*2. Afisati cel mai tanar student
• In mai multe moduri*/

            //1
            var youngestStudent = students.Where(s => s.Age == students.Min(s => s.Age));
            Console.WriteLine("Youngest students are:");
            foreach (var student in youngestStudent)
            {
                Console.WriteLine($"{student}");
            }
            //2
            var smallestAge = students.Min(s => s.Age);
            var youngestStudent2 = from student in students
                                   where student.Age == smallestAge
                                   select student;
            Console.WriteLine("Youngest students are:");
            foreach (var student in youngestStudent2)
            {
                Console.WriteLine($"{student}");
            }
            //3
            var groupStudents = students.GroupBy(s => s.Age);
            Console.WriteLine("Youngest students are:");
            foreach (var group in groupStudents)
            {
                if (group.Key == smallestAge)
                {
                    foreach (var student in group)
                        Console.WriteLine($"{student}");
                }
            }

            /*3. Afisati in ordine crescatoare a varstei toti,
            studentii de la litere.*/

            var languagesStudents = students.Where(s => s.Major == Student.MajorType.Languages).OrderBy(s => s.Age);
            int order = 1;
            Console.WriteLine("Languages students orederd by age are:");
            foreach (var student in languagesStudents)
            {
                Console.WriteLine($"{order}. {student}");
                order++;
            }


            /*4. Afisati primul student de la constructii cu
            varsta de peste 20 de ani*/

            var firstConstructionStudentOver20 = students.Where(s => s.Major == Student.MajorType.Constructions).First(s => s.Age > 20);
            Console.WriteLine($"First construcion student over 20 years of age: {firstConstructionStudentOver20}");

            /*5. Afisati studentii avand varsta egala cu
            varsta medie a studentilor*/

            var avergaeAgeStudents = students.Where(s => s.Age == (int)students.Average(s => s.Age));
            order = 1;
            foreach (var student in avergaeAgeStudents)
            {
                Console.WriteLine($"Student with average age {order}. {student}");
                order++;
            }

            /*6. Afisati, in ordinea descrescatoare a varstei,
            si in ordine alfabetica, dupa numele de
            familie si dupa numele mic, toti studentii
            cu varsta cuprinsa intre 18 si 35 de ani*/
            var orderByStudents = students.OrderByDescending(s => s.Age).ThenBy(s => s.LastName).ThenBy(s => s.FirstName).Where(s => s.Age > 18 && s.Age < 35);
            order = 1;
            Console.WriteLine($"OrderBy students:");
            foreach (var student in orderByStudents)
            {
                Console.WriteLine($"{order}. {student}");
                order++;
            }

            /*7. Afisati ultimul elev din lista folosind linq
                         */
            var lastStudentInList = students.LastOrDefault();
            Console.WriteLine($"Last student in list: {lastStudentInList}");

            /*8. Afisati mesajul “Exista si minori” daca in lista
creeata exista si persone cu varsta mai mica de
18 ani. In caz contar afesati “Nu exista minori”
                        */
            if (students.Any(s => s.Age < 18))
            {
                Console.WriteLine($"There are underage students in list");
            }
            else
            {
                Console.WriteLine($"No underage students in list");
            }

            /*
             Suplimentar
9. Folosind GroupBy, afisati toti studentii grupati
in functie de varsta sub forma urmatoare
Studentii cu varsta de 20 de ani
Student1.toString
Student2.toString
Student3.toString
Studentii cu varsta de 25 de ani
.
.
.*/
            var groupByStudents = students.GroupBy(s => s.Age);
            Console.WriteLine("GroupBy students:");
            foreach (var group in groupByStudents)
            {
                if (group.Key == 20)
                {
                    foreach (var student in group)
                        Console.WriteLine($".{student}");
                }
                if (group.Key == 25)
                {
                    foreach (var student in group)
                        Console.WriteLine(student);
                }
            }

        }
        private static List<Student> GetStudents =>
            new List<Student>()
            {
                new Student
                {
                    FirstName="Ionut",
                    LastName="Antonescu",
                    Age=20,
                    Major=Student.MajorType.Constructions
                },
                 new Student
                {
                    FirstName="Ioana",
                    LastName="Popescu",
                    Age=20,
                    Major=Student.MajorType.Languages
                },
                  new Student
                {
                    FirstName="Dan",
                    LastName="Bitman",
                    Age=45,
                    Major=Student.MajorType.Constructions
                },
                   new Student
                {
                    FirstName="Crina",
                    LastName="Manea",
                    Age=30,
                    Major=Student.MajorType.Informatics
                },
                    new Student
                {
                    FirstName="George",
                    LastName="Trifan",
                    Age=22,
                    Major=Student.MajorType.Constructions
                },
                     new Student
                {
                    FirstName="Paul",
                    LastName="Dobre",
                    Age=18,
                    Major=Student.MajorType.Languages
                },
                      new Student
                {
                    FirstName="Diana",
                    LastName="Velescu",
                    Age=25,
                    Major=Student.MajorType.Constructions
                },
                       new Student
                {
                    FirstName="John",
                    LastName="Carpenter",
                    Age=21,
                    Major=Student.MajorType.Languages
                },
                        new Student
                {
                    FirstName="Ionut",
                    LastName="Antonescu",
                    Age=22,
                    Major=Student.MajorType.Constructions
                },
                         new Student
                {
                    FirstName="Lucian",
                    LastName="Coman",
                    Age=31,
                    Major=Student.MajorType.Languages
                },
                          new Student
                {
                    FirstName="Andreea",
                    LastName="Caliman",
                    Age=35,
                    Major=Student.MajorType.Informatics
                },
                           new Student
                {
                    FirstName="George",
                    LastName="Antonescu",
                    Age=20,
                    Major=Student.MajorType.Constructions
                },
                           new Student
                {
                    FirstName="Andreea",
                    LastName="Coman",
                    Age=18,
                    Major=Student.MajorType.Languages
                },
                           new Student
                {
                    FirstName="Razvan",
                    LastName="Florea",
                    Age=25,
                    Major=Student.MajorType.Informatics
                },
                           new Student
                {
                    FirstName="Gheorghe",
                    LastName="Gherghel",
                    Age=42,
                    Major=Student.MajorType.Constructions
                },
                           new Student
                {
                    FirstName="Izabela",
                    LastName="Popa",
                    Age=21,
                    Major=Student.MajorType.Languages
                },
                           new Student
                {
                    FirstName="Sebi",
                    LastName="Popa",
                    Age=21,
                    Major=Student.MajorType.Languages
                },

            };
    }
}
