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

   

    class Program
    {
        static void WriteBaseClassInfo(Type type)
        {
            Console.WriteLine();

            Console.WriteLine(type.Name);

            Console.WriteLine("BaseType: " + type.BaseType);

            Console.Write("Interface: ");
            foreach (var i in type.GetInterfaces())
            {
                Console.Write(" " + i.Name);
            }
            Console.WriteLine();

            Console.WriteLine("is class: " + type.IsClass);
            Console.WriteLine("is abstract: " + type.IsAbstract);
            Console.WriteLine("is interface: " + type.IsInterface);

        }
        static void WriteClassInfoFull(Type type)
        {
            WriteBaseClassInfo(type);


            foreach (var item in type.GetFields())
            {
                Console.WriteLine(item);
             
            }
            foreach (var item in type.GetMethods())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        static void WriteClassInfoCleaned(Type type)
        {

            if (type.Name.StartsWith("<>") == true)
            {
                return;
            }


            WriteBaseClassInfo(type);


            foreach (var item in type.GetFields())
            {

                Console.WriteLine(item);

            }
            foreach (var item in type.GetMethods())
            {

                if(item.Name=="Equals")
                {
                    continue;
                }
                if(item.Name=="GetHashCode")
                {
                    continue;
                }
                if (item.Name == "GetType")
                {
                    continue;
                }
                if (item.Name == "ToString")
                {
                    continue;
                }


                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

          //  MainTest(assembly);

            CodeToObjectConverter codeToObjectConverter = new CodeToObjectConverter();


            List<Type> typelist = new List<Type>();
            var namespaces = assembly.GetTypes()
                           .Select(t => t.Namespace)
                           .Distinct();
            foreach (var space in namespaces)
            {

                typelist.AddRange(GetTypesInNamespace(assembly, space).ToList());
            }


            codeToObjectConverter.CreateStructure(typelist);
            // codeToObjectConverter.CreateClasses(GetTypesInNamespace(assembly, "ReflectionTest"));

            ObjectToPlantUMLConverter PlantUML = new ObjectToPlantUMLConverter();
            PlantUML.CodeToObjectConverter = codeToObjectConverter;

            Console.WriteLine(PlantUML.CreateFilePlantUML());




            Console.ReadLine();
           
        }

        static void MainTest(Assembly assembly)
        {
            ClassNameUML name = new ClassNameUML();
            name.ClassType = ClassTypes.AbstractClass;




            Klasa2 klasa2 = new Klasa2();
            Klasa3 klasa3 = new Klasa3();

            MemberInfo info = typeof(Klasa2);

            var namespaces = assembly.GetTypes()
                            .Select(t => t.Namespace)
                            .Distinct();

            List<Type> typelist =new List<Type>();


            foreach (var space in namespaces)
            {
                
                typelist.AddRange(GetTypesInNamespace(assembly, space).ToList());
            }

            for (int i = 0; i < typelist.Count; i++)
            {
                WriteClassInfoFull(typelist[i]);
            }




            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Cleaned Info");
            Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); Console.WriteLine();




            for (int i = 0; i < typelist.Count; i++)
            {
                WriteClassInfoCleaned(typelist[i]);
            }
            Console.WriteLine();
            //Klasa1

            Console.ReadLine();
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
