using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Models
{
    public enum ClassTypes 
    { 
        Class,
        AbstractClass, 
        Interface,
        Enum
    }
    [Flags]
    public enum Accesibilities 
    {
        None = 0x0000,
        Private = 0x0001,
        Protected = 0x0002,
        Internal = 0x0004,
        ProtectedInternal = 0x0008,
        Public = 0x0010,
    }
   
    //NOT TO IMPLEMENT RIGHT NOW
    [Flags]
    public enum Modifiers
    {
        Static,
        Virtual,
        Abstract,
        Override
    }


}
