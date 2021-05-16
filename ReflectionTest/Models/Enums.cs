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
    public enum ConnectionTypes
    {
        Association,
        Aggregation,
        Composition,
        Inheritance,
        Realization
    }
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
