using ReflectionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Converters
{
    public class ObjectToPlantUMLConverter
    {
        public CodeToObjectConverter CodeToObjectConverter { get; set; }

        public string CreateFilePlantUML()
        {          

            StringBuilder code = new StringBuilder();

            code.Append("@startuml\n");


            code.Append(ReadClasses());


            code.Append("@enduml");

            return code.ToString();
        }
        public string ReadClasses()
        {
            StringBuilder code = new StringBuilder();


            foreach (var classUML in CodeToObjectConverter.Objects)
            {
                code.Append(ReadClass(classUML));
            }

            return code.ToString();
        }
        public string ReadClass(ClassUML classUML)
        {
            StringBuilder code = new StringBuilder();
 
            code.Append(ReadClassAccesibility(classUML.ClassName.FullAccesibility) + ReadClassType(classUML.ClassName.ClassType) + " " + classUML.ClassName.ClassName + " {\n");
            code.Append(ReadClassInside(classUML));
            code.Append("}\n");
           


            return code.ToString();
        }

        public string ReadClassInside(ClassUML classUML)
        {
            StringBuilder code = new StringBuilder();

            //TODO - add accesibility
            code.Append(ReadFields(classUML));
            code.Append(ReadMethods(classUML));
            
           
            return code.ToString();
        }

        public string ReadFields(ClassUML classUML)
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
                    code.Append(ReadAccesibility(field.FullAccesibility) + field.FieldType + " " + field.FieldName + "\n");
                }
            }

            return code.ToString();
        }
        public string ReadMethods(ClassUML classUML)
        {
            StringBuilder code = new StringBuilder();

            foreach (var method in classUML.Methods)
            {
                code.Append(ReadAccesibility(method.FullAccesibility) + method.ReturnType + " " + method.MethodName + "(" + ReadMethodArguments(method) + ")" + "\n");
            }

            return code.ToString();
        }

        public string ReadMethodArguments(MethodUML method)
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




        public string ReadClassType(ClassTypes classType)
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
        public string ReadClassAccesibility(AccesibilityUML accesibility)
        {
            StringBuilder code = new StringBuilder();
            

            return code.ToString();
        }

        public string ReadAccesibility(AccesibilityUML accesibility)
        {
            StringBuilder code = new StringBuilder();

            if(accesibility.Modifier == Modifiers.Static)
            {
                code.Append("{static} ");
            }
            if (accesibility.Modifier == Modifiers.Abstract)
            {

                code.Append("{abstract} ");
            }

            if(accesibility.Accesibility == Accesibilities.Private)
            {
                code.Append("-");
            }
            else if (accesibility.Accesibility == Accesibilities.Protected)
            {
                code.Append("#");
            }
            else if (accesibility.Accesibility == Accesibilities.Internal)
            {
                code.Append("~");
            }
            else if (accesibility.Accesibility == Accesibilities.Public)
            {
                code.Append("+");
            }


            return code.ToString();
        }


        //TODO RETURN ACCESIBILITY
    }
}
