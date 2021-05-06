using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest
{
    public abstract class AbstractKlasa
    {
        public Klasa2 ReferencedObject { get; set; }

        public abstract void AbstractMethod(int number);

    }
}
