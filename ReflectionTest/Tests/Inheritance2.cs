using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Tests
{
    class Inheritance2 : Inheritance, InterfaceKlasa
    {
        public void Method1()
        {
            throw new NotImplementedException();
        }

        public int Method2(int arg1)
        {
            throw new NotImplementedException();
        }
    }
}
