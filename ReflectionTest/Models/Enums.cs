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
    public enum Accesibilities 
    {
        None,
        Public,
        Private,
        Protected,
        Internal,
        ProtectedInternal,
        PrivateProtected
    }
   
    //NOT TO IMPLEMENT RIGHT NOW
    [Flags]
    public enum Modifiers
    {
        None,
        Static,
        Virtual,
        Abstract,
        Override
    }


}
