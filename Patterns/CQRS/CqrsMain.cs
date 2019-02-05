using CQRS.Commands;
using CQRS.Queries;
using System.Data.SqlClient;

namespace CQRS
{
    public class CqrsMain
    {
        public void Run()
        {
            var sqlConnection = new SqlConnection("dbConnectionString");

            var getDogsHandler = new GetDogHandler(sqlConnection);

            var saveDogHandler = new SaveDogHandler(new SqlConnection("dbConnection"), getDogsHandler);
        }
    }
}