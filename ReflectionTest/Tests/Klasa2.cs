using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    public class Klasa2
    {
        private string Word = "Slowo";
        protected int Number;
        public bool Condition;
        char Character;
        public int MyProperty { get; set; }

        public void MethodVoid()
        {
            Console.WriteLine("MethodVoid");
        }
        public int MethodVoid(int arg1)
        {
            return arg1;
        }


    }
}
