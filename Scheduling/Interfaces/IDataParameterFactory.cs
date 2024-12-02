using System.Data;

namespace Scheduling.Interfaces
{
    internal interface IDataParameterFactory
    {
        IDbDataParameter CreateParameter(string name, object value);
    }
}
