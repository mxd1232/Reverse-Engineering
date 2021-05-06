using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Models
{
    public class ClassUML
    {

        public ClassNameUML ClassName { get; set; }
        public List<FieldUML> Fields { get; set; }
        public List<MethodUML> Methods { get; set; }
    }
    
}
