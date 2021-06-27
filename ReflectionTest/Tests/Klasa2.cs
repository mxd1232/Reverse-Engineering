using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Tests
{
    public class Klasa2
    {
        public List<List<List<Klasa3>>> klassss;
        private Klasa2 klasa2;
        private Klasa3 klasa3;
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
