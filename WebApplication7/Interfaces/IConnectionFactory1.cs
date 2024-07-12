using System.Data;

namespace RestuarantCRM.Interfaces
{
    public interface IConnectionFactory1
    {
        IDbConnection CreateConnection();
    }
}
