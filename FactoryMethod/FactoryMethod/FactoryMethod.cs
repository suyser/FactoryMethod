using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryMethod.College;
namespace FactoryMethod.FactoryMethod
{
    public abstract class FactoryMethod
    {
        public static Attributes FabrickMethod(string line)
        {
            string[] param = line.Split(',');   
            int id = int.Parse(param[1]);
            string name  = param[2];

            switch (param[0].ToLower())
            {
                case "teacher":
                    return new Teacher(id, name);
                case "student":
                    return new Student(id, name);
                case "course":
                    return new Course(id, name);
                default:
                    return null;
            }
        }
    }
}
