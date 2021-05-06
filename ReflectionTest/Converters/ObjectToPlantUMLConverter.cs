using ReflectionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Converters
{
    class ObjectToPlantUMLConverter
    {
        public CodeToObjectConverter CodeToObjectConverter { get; set; }

        public string CreateFilePlantUML()
        {          

            StringBuilder code = new StringBuilder();

            code.Append("@startuml\n");


            code.Append(CreateClasses());


            code.Append("@enduml");

            return code.ToString();
        }
        public string CreateClasses()
        {
            StringBuilder code = new StringBuilder();


            foreach (var Object in CodeToObjectConverter.Objects)
            {
                code.Append(ReturnClassType(Object.ClassName.ClassType) + " " + Object.ClassName.ClassName + " {\n");

                //Inside of a class
                code.Append(ReturnClassInside(Object));

                code.Append("}\n");
            }



            return code.ToString();
        }
        public string ReturnClassInside(ClassUML classUML)
        {
            StringBuilder code = new StringBuilder();

            //TODO - add accesibility
            code.Append(ReturnFields(classUML));
            code.Append(ReturnMethods(classUML));
            
           
            return code.ToString();
        }

        public string ReturnFields(ClassUML classUML)
        {
            StringBuilder code = new StringBuilder();
            if(classUML.ClassName.ClassType==ClassTypes.Enum)
            {
                foreach (var field in classUML.Fields)
                {
                    code.Append(field.FieldName + "\n");
                }
            }
            else
            {
                foreach (var field in classUML.Fields)
                {
                    code.Append(field.FieldType + " " + field.FieldName + "\n");
                }
            }

            return code.ToString();
        }
        public string ReturnMethods(ClassUML classUML)
        {
            StringBuilder code = new StringBuilder();

            foreach (var method in classUML.Methods)
            {
                code.Append(method.ReturnType + " " + method.MethodName + "(" + ReturnMethodArguments(method) + ")" + "\n");
            }

            return code.ToString();
        }

        public string ReturnMethodArguments(MethodUML method)
        {
            if (method.Parameters.Count==0)
                return "";


            StringBuilder code = new StringBuilder();

            foreach (var argument in method.Parameters)
            {
                code.Append(argument.ParameterType + " " + argument.ParameterName +" ");
            }
            code.Remove(code.Length - 1, 1);

            return code.ToString();
        }




        public string ReturnClassType(ClassTypes classType)
        {
            switch (classType)
            {
                case ClassTypes.Class:
                    return "class";
                case ClassTypes.AbstractClass:
                    return "abstract class";
                case ClassTypes.Interface:
                    return "interface";
                case ClassTypes.Enum:
                    return "enum";
                default:
                    throw new Exception();
                

            }

        }

    }
}
