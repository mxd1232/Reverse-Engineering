using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Tests
{
    public static class StaticClass
    {
        public static object staticArgument;
        public static int method(int intArgument)
        {
            return intArgument;
        }
    }
}
