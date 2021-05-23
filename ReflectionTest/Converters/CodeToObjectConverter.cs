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
        public HashSet<ConnectionUML> Connections { get; set; } = new HashSet<ConnectionUML>(new ConnectionComparer());

       

        public void CreateStructure(List<Type> typeList)
        {
            Objects = new List<ClassUML>();

            foreach (var type in typeList)
            {
                CreateClass(type);
            }

            CreateConnections();
        }
        public void CreateConnections()
        {
            CreateInheritance();
            CreateDependencies();
            CreateAssociations();
          //  CreateAggregations();
          //  CreateCompositions();
        }
        public void CreateInheritance()
        {
            foreach (var obj in Objects)
            {
                if (obj.ClassName.BaseType != null)
                {
                    Connections.Add(
                    new ConnectionUML()
                    {
                        Class = obj.ClassName.ClassName,
                        ConnectedClass = obj.ClassName.BaseType,
                        ConnectionType = ConnectionTypes.Inheritance
                    }
                    );
                }
                foreach (var interf in obj.ClassName.Interfaces)
                {
                    if (Objects.Exists(x => x.ClassName.ClassName == interf))
                    {
                        Connections.Add(
                        new ConnectionUML()
                        {
                            Class = obj.ClassName.ClassName,
                            ConnectedClass = interf,
                            ConnectionType = ConnectionTypes.Implementation
                        });

                    }
                }
            }
        }
        public void CreateDependencies()
        {
            //TODO - double dependency

            foreach (var obj in Objects)
            {

                foreach (var method in obj.Methods)
                {
                    if (Objects.Exists(x => x.ClassName.ClassName == method.ReturnType))
                    {
                        Connections.Add(
                        new ConnectionUML()
                        {
                            Class = obj.ClassName.ClassName,
                            ConnectedClass = method.ReturnType,
                            ConnectionType = ConnectionTypes.Dependency
                        });
                    }
                    foreach (var methodParameter in method.Parameters)
                    {
                        if (Objects.Exists(x => x.ClassName.ClassName == methodParameter.ParameterType))
                        {
                            Connections.Add(
                            new ConnectionUML()
                            {
                                Class = obj.ClassName.ClassName,
                                ConnectedClass = methodParameter.ParameterType,
                                ConnectionType = ConnectionTypes.Dependency
                            });
                        }
                    }
                    
                }
            }
        }
        public void CreateAssociations()
        {
            //TODO - double Associations

            foreach (var obj in Objects)
            {
                if(obj.ClassName.ClassType==ClassTypes.Enum)
                {
                    continue;
                }
                foreach (var field in obj.Fields)
                {
                    if (Objects.Exists(x => x.ClassName.ClassName == field.FieldType))
                    {
                        Connections.Add(
                        new ConnectionUML()
                        {
                            Class = obj.ClassName.ClassName,
                            ConnectedClass = field.FieldType,
                            ConnectionType = ConnectionTypes.Association
                        });
                    }
                }
            }
        }
        public void CreateAggregations()
        {
            throw new NotImplementedException();
        }
        public void CreateCompositions()
        {
            throw new NotImplementedException();
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

            AddProperties(classUML);

            Objects.Add(classUML);

            
            //TODO -ADD CONNECTIONS


        }
        private void AddProperties(ClassUML classUML)
        {
            foreach (var method in classUML.Methods)
            {
                string methodName = method.MethodName;

                if ( methodName.StartsWith("get_"))
                {
                    string propertyName = methodName.Substring(4);

                    if(classUML.Fields.Exists(x => x.FieldName == propertyName)==false)
                    {
                        classUML.Fields.Add(new FieldUML()
                        {
                            FieldName = propertyName,
                            FieldType = method.ReturnType, 
                            FullAccesibility = (new AccesibilityUML()
                            {
                                Accesibility = Accesibilities.None,
                                Modifier = Modifiers.None
                            })
                        });
                    }
                }
                if (methodName.StartsWith("set_"))
                {
                    string propertyName = methodName.Substring(4);

                    if (classUML.Fields.Exists(x => x.FieldName == propertyName) == false)
                    {
                        classUML.Fields.Add(new FieldUML()
                        {
                            FieldName = propertyName,
                            FieldType = method.Parameters[0].ParameterType,
                            FullAccesibility = (new AccesibilityUML()
                            {
                                Accesibility = Accesibilities.None,
                                Modifier = Modifiers.None
                            })
                        });
                    }
                }
            }


        }
        private ClassNameUML CreateClassName(Type type)
        {
            ClassNameUML classNameUML = new ClassNameUML
            {
                ClassName = type.Name,
                ClassType = GetClassType(type),
                FullAccesibility = CreateClassAccesibility(type),            
            };

            if (type.BaseType != null  )
            {
                if(type.BaseType.Name != "Object" && type.BaseType.Name != "Enum")
                {
                    classNameUML.BaseType = type.BaseType.Name;
                }
                
            }
            foreach (var item in type.GetInterfaces())
            {
                classNameUML.Interfaces.Add(item.Name);
            }
            

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
                if (fieldInfo.Name == "value__")
                {
                    continue;
                }
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
