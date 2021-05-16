using System.Collections.Generic;

namespace ReflectionTest.Models
{
    public class ClassNameUML
    {
        public string ClassName { get; set; }
        public ClassTypes ClassType { get; set; }
        public AccesibilityUML FullAccesibility { get; set; }
        public string BaseType { get; set; }
        public List<string> Interfaces { get; set; } = new List<string>();

    }
}