using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduling.Interfaces
{
    internal interface IDataParameterFactory
    {
        IDbDataParameter CreateParameter(string name, object value);
    }
}
