using ReflectionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTest.Converters
{
    class ConnectionComparer : IEqualityComparer<ConnectionUML>
    {
        public bool Equals(ConnectionUML x, ConnectionUML y)
        {
            return (
                x.Class.Equals(y.Class,StringComparison.InvariantCulture)
                && x.ConnectedClass.Equals(y.ConnectedClass,StringComparison.InvariantCulture)
                && x.ConnectionType.Equals(y.ConnectionType)
                );
        }

        public int GetHashCode(ConnectionUML obj)
        {
            return obj.Class.GetHashCode() + obj.ConnectedClass.GetHashCode() + obj.ConnectionType.GetHashCode();
        }
    }
}
