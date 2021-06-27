using ReflectionTest.Converters;
using ReflectionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{

   

    class PlantUMLGenerator
    {  
        static void Main(string[] args)
        {
            Console.WriteLine(CreatePlantUML(GetAllTypesInAssembly()));
            Console.ReadKey();
        }
        private static List<Type> GetAllTypesInAssembly()
        {
            Console.WriteLine("to get classes from Classes Folder press 1. \n to get classes of the converter  press 2. \n to get classes from dll file write a full path press anything else");

            string choice =  Console.ReadLine();

            Assembly assembly;
            if (choice == "1")
            {
                string filePath = Console.ReadLine();

                assembly = Assembly.LoadFile(filePath);
                    //Assembly.LoadFile(@"C:\Users\Mikołaj\source\repos\DllTest\DllTest\bin\Debug\DllTest.dll");

            }
            else
            {
                assembly = Assembly.GetExecutingAssembly();

            }
            Console.Clear();

            List<Type> typelist = new List<Type>();
            var namespaces = assembly.GetTypes()
                           .Select(t => t.Namespace)
                           .Distinct();

            if(choice == "2")
            {
                foreach (var space in namespaces)
                {
                    if (space == "ReflectionTest.Tests")
                    {
                        continue;
                    }

                    typelist.AddRange(GetTypesInNamespace(assembly, space).ToList());
                }
            }
            else
            {
                foreach (var space in namespaces)
                {
                    if (space == "ReflectionTest.Tests" || space == "ReflectionTest.Models" ||space == "ReflectionTest.Converters" || space == "ReflectionTest")
                    {
                        continue;
                    }

                    typelist.AddRange(GetTypesInNamespace(assembly, space).ToList());
                }
            }

            
           

            return typelist;
        }
        private static string CreatePlantUML(List<Type> typelist)
        {
            CodeToObjectConverter codeToObjectConverter = new CodeToObjectConverter();
            codeToObjectConverter.CreateStructure(typelist);

            ObjectToPlantUMLConverter PlantUML = new ObjectToPlantUMLConverter();
            PlantUML.CodeToObjectConverter = codeToObjectConverter;

            return PlantUML.CreateFilePlantUML();     
        }

     
        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return
              assembly.GetTypes()
                      .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                      .ToArray();
        }
    }
}
