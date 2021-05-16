using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Models
{
    public class ConnectionUML
    {
        public string Class { get; set; }
        public string ConnectedClass { get; set; }
        public ConnectionTypes ConnectionType { get; set; }
    }
} 
