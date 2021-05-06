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
                ClassType = GetClassType(type),
                FullAccesibility = CreateClassAccesibility(type)
            };
            return classNameUML;
        }

        private ClassTypes GetClassType(Type type)
        {
            ClassTypes classType;



            if (type.IsClass == true && type.IsAbstract == false || (type.IsSealed == true && type.IsAbstract == true))
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
                FullAccesibility = CreateFieldAccesibility(fieldInfo),
                FieldType = fieldInfo.FieldType.Name
              //TODO - starting value?
              
            };

            

            return fieldUML;
           
        }
        private AccesibilityUML CreateFieldAccesibility(FieldInfo fieldInfo)
        {
            AccesibilityUML accesibility = new AccesibilityUML();


            if(fieldInfo.IsPublic)
            {
                accesibility.Accesibility = Accesibilities.Public;
            }
            else if (fieldInfo.IsPrivate)
            {
                accesibility.Accesibility = Accesibilities.Private;
            }
            else if(fieldInfo.IsAssembly)
            {
                accesibility.Accesibility = Accesibilities.Internal;
            }        
            else if (fieldInfo.IsFamily)
            {
                accesibility.Accesibility = Accesibilities.Protected;
            }
            else if (fieldInfo.IsFamilyOrAssembly)
            {
                accesibility.Accesibility = Accesibilities.ProtectedInternal;
            }
            else if (fieldInfo.IsFamilyAndAssembly)
            {
                accesibility.Accesibility = Accesibilities.PrivateProtected;
            }
            if (fieldInfo.IsStatic)
            {
                accesibility.Modifier |= Modifiers.Static;
            }


            return accesibility;
        }
        private List<MethodUML> CreateMethods(Type type)
        {
            List<MethodUML> methods = new List<MethodUML>();

            foreach (var methodInfo in type.GetMethods())
            {

                if (methodInfo.Name == "Equals" || 
                    methodInfo.Name == "GetHashCode" || 
                    methodInfo.Name == "GetType" || 
                    methodInfo.Name == "ToString"||
                    methodInfo.Name == "CompareTo" ||
                    methodInfo.Name == "HasFlag" ||
                    methodInfo.Name == "GetTypeCode" 
                    )
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
            {
                MethodName = methodInfo.Name,
                FullAccesibility = CreateMethodAccesibility(methodInfo),
                ReturnType = methodInfo.ReturnType.Name,
            
            };

            if (methodInfo != null && methodInfo.GetParameters().Length > 0)
            {
                foreach (var argument in methodInfo.GetParameters())
                {
                    method.Parameters.Add(
                        new ParameterUML()
                        {
                            ParameterType = argument.ParameterType.Name,
                            ParameterName = argument.Name
                        }
                ); ;
                        
                        
                }
            }
            return method;
        }
        private AccesibilityUML CreateMethodAccesibility(MethodInfo methodInfo)
        {

            AccesibilityUML accesibility = new AccesibilityUML();


            if (methodInfo.IsPublic)
            {
                accesibility.Accesibility = Accesibilities.Public;
            }
            else if (methodInfo.IsPrivate)
            {
                accesibility.Accesibility = Accesibilities.Private;
            }
            else if (methodInfo.IsAssembly)
            {
                accesibility.Accesibility = Accesibilities.Internal;
            }
            else if (methodInfo.IsFamily)
            {
                accesibility.Accesibility = Accesibilities.Protected;
            }
            else if (methodInfo.IsFamilyOrAssembly)
            {
                accesibility.Accesibility = Accesibilities.ProtectedInternal;
            }
            else if (methodInfo.IsFamilyAndAssembly)
            {
                accesibility.Accesibility = Accesibilities.PrivateProtected;
            }

            if(methodInfo.IsStatic)
            {
                accesibility.Modifier |= Modifiers.Static;
            }
            if(methodInfo.IsAbstract)
            {
                accesibility.Modifier |= Modifiers.Abstract;
            }

            

            return accesibility;
        }

        private AccesibilityUML CreateClassAccesibility(Type type)
        {
            //TODO - public,protected,internal

            AccesibilityUML accesibility = new AccesibilityUML();

            return accesibility;
        }
    }
}
