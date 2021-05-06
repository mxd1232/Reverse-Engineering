using System.Collections.Generic;

namespace ReflectionTest.Models
{
    public class MethodUML
    {
        public string MethodName { get; set; }
        public string Visibility { get; set; }
        public string ReturnType { get; set; }
        public List<string> Arguments { get; set; } = new List<string>();


        //TODO-?   public Accesibilities Accesibility { get; set; }
        //TODO-?  public DataTypes DataType { get; set; }

    }
}