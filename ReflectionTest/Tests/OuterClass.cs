using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Tests
{
    class OuterClass
    { 
        class NestedClass
        {
            class DoubleNestedClass
            {
                int hiddenField=6;
            }
        }
    }
}
