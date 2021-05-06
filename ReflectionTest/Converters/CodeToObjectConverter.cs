using ReflectionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Converters
{
    public class CodeToObjectConverter
    {
        public List<ClassUML> Objects { get; set; } = new List<ClassUML>();
        public List<ConnectionUML> Connections { get; set; } = new List<ConnectionUML>();

        public void CreateClasses(List<Type> typeList)
        {
            Objects = new List<ClassUML>();

            foreach (var type in typeList)
            {
                CreateClass(type);
            }

        }
  
        public void CreateClass(Type type)
        {
            ClassUML classUML = null;

            if (type.Name.StartsWith("<>") == true)
            {
                return;
            }

            classUML = new ClassUML();

            //CLASS NAME
            classUML.ClassName = CreateClassName(type);


            //CLASS FIELDS

            classUML.Fields = CreateFields(type);

            //CLASS METHODS

            classUML.Methods = CreateMethods(type);

            Objects.Add(classUML);
           

        }
        private ClassNameUML CreateClassName(Type type)
        {
            ClassNameUML classNameUML = new ClassNameUML
            {
                ClassName = type.Name,
                ClassType = GetClassType(type)
            };
            return classNameUML;
        }
        private ClassTypes GetClassType(Type type)
        {
            ClassTypes classType;

            if (type.IsClass == true && type.IsAbstract == false)
            {
                classType = ClassTypes.Class;
            }
            else if (type.IsInterface == true)
            {
                classType = ClassTypes.Interface;
            }
            else if (type.IsClass == true && type.IsAbstract == true)
            {
                classType = ClassTypes.AbstractClass;
            }
            else if (type.IsEnum)
            {
                classType = ClassTypes.Enum;
            }
            else
            {
                throw new Exception();
            }
            return classType;
        }
        private List<FieldUML> CreateFields(Type type)
        {
            List<FieldUML> fields = new List<FieldUML>();

            foreach (var fieldInfo in type.GetFields())
            {
                fields.Add(CreateField(fieldInfo));
            }

            return fields;
        }
        private FieldUML CreateField(FieldInfo fieldInfo)
        {
            FieldUML fieldUML = new FieldUML()
            {
                FieldName =fieldInfo.Name,
                //TODO - ACCESIBILITY
                FieldType = fieldInfo.FieldType.ToString()
              //  StartingValue = fieldInfo.GetValue(null).ToString()
              //TODO - starting value?
            };

            return fieldUML;
           
        }
        private List<MethodUML> CreateMethods(Type type)
        {
            List<MethodUML> methods = new List<MethodUML>();

            foreach (var methodInfo in type.GetMethods())
            {

                if (methodInfo.Name == "Equals" || methodInfo.Name == "GetHashCode" || methodInfo.Name == "GetType" || methodInfo.Name == "ToString")
                {
                    continue;
                }

                methods.Add(CreateMethod(methodInfo));
            }

            return methods;
        }

        private MethodUML CreateMethod(MethodInfo methodInfo)
        {
            MethodUML method = new MethodUML()
            {MethodName = methodInfo.Name,
            //TODO Visibility
            ReturnType = methodInfo.ReturnType.ToString(),
            
            };

            if (methodInfo != null && methodInfo.GetParameters().Length > 0)
            {
                foreach (var argument in methodInfo.GetParameters())
                {
                    method.Arguments.Add(argument.ParameterType.ToString());
                }
            }
            return method;
        }
    }
}
