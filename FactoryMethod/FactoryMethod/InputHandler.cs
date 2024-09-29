using FactoryMethod.College;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod.FactoryMethod
{
    class InputHandler
    {
        public static void CreateField(string line)
        {
            var obj = FactoryMethod.FabrickMethod(line);
            if (obj is Teacher teacher)
            {
                InputHandler inputHandler = new InputHandler();
                Console.WriteLine("Введите YES, чтобы добавить опыт работы и курсы, иначе введите NO");

                if (Console.ReadLine().ToLower() == "yes")
               {
                    Console.WriteLine("Введите опыт работы:");
                    int experience = int.Parse(Console.ReadLine());
                    teacher.SetExperience(experience);
                    Console.WriteLine("Введите курсы в формате <course1> <course2>");
                    string[] courses = Console.ReadLine().Split(' ');
                    teacher.SetCourses(courses);
               }
                string course = "";
                foreach (var temp in teacher.Courses)
                {
                    course += temp.ToString() + ", ";
                }
                string field = $"Teacher:\n" +
                    $"Id -> {teacher.Id}\n" +
                    $"Name -> {teacher.Name}\n" +
                    $"Expirience -> {teacher.Experience}\n" +
                    $"Courses -> {course}\n";
                
                inputHandler.WriteToFile(field);

            }
            else if (obj is Student student)
            {
                InputHandler inputHandler = new InputHandler();
                Console.WriteLine("Введите YES, чтобы добавить курсы, иначе введите NO");

                if (Console.ReadLine().ToLower() == "yes")
                {
                    Console.WriteLine("Введите курсы в формате <course1> <course2>");
                    string[] courses = Console.ReadLine().Split(' ');

                    student.SetCourses(courses);
                }
                string course = "";
                foreach (var temp in student.Courses)
                {
                    course += temp.ToString() + ", ";
                }

                string field = $"Student:\n" +
                    $"Id -> {student.Id}\n" +
                    $"Name -> {student.Name}\n" +
                    $"Courses -> {course}\n";

                inputHandler.WriteToFile(field);
            }
            else if (obj is Course course)
            {
                InputHandler inputHandler = new InputHandler();
                Console.WriteLine("Введите YES, чтобы добавить курсы, иначе введите NO");


                if (Console.ReadLine().ToLower() == "yes")
                {
                    Console.WriteLine("Введите id Студентов этого курса");
                    course.Student_Id = Console.ReadLine().Split(' ');
                    Console.WriteLine("Введите id Учителей этого курса");
                    course.Teacher_Id = Console.ReadLine().Split(' ');
                }
                
                string field = $"Course:\n" +
                    $"Id -> {course.Id}\n" +
                    $"Student Name -> {course.Name}\n" +
                    $"Student_id -> {course.Student_Id}\n" +
                    $"Teacher_id -> {course.Teacher_Id}\n";

                inputHandler.WriteToFile(field);
            }
        }

        void WriteToFile(string line)
        {
            string filePath = @"C:\proga\FactoryMethod\FactoryMethod\db.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
            }
        }

        public static void ReadFile()
        {
            string filePath = @"C:\proga\FactoryMethod\FactoryMethod\db.txt";

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                }
            }
        }

        public static void ReadFile(string field)
        {
            string filePath = @"C:\proga\FactoryMethod\FactoryMethod\db.txt";


            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(field)) Console.WriteLine(line);
                }
            }
        }
    }
}
