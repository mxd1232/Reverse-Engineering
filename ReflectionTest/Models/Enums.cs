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
        Public,
        Private,
        Protected,
        Internal,
        ProtectedInternal,
        PrivateProtected 
    }
    public enum DataTypes 
    { 
        Byte,
        SByte,
        SHort,
        UShort,
        Int,
        UInt,
        Long,
        ULong,
        Float,
        Double,
        Decimal,
        Char,
        Bool,
        Object,
        String,
        DateTime,
        _Other
    }


    //NOT TO IMPLEMENT RIGHT NOW
    public enum Modifiers
    {
        Static,
        Virtual,
        Abstract,
        Override
    }


}
