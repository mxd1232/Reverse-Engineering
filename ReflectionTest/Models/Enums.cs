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
