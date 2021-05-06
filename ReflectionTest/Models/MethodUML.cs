using System.Collections.Generic;

namespace ReflectionTest.Models
{
    public class MethodUML
    {
        public string MethodName { get; set; }
        public string ReturnType { get; set; }
        public List<ParameterUML> Parameters { get; set; } = new List<ParameterUML>();

        public AccesibilityUML FullAccesibility { get; set; }


        //TODO-?   public Accesibilities Accesibility { get; set; }
        //TODO-?  public DataTypes DataType { get; set; }

    }
}