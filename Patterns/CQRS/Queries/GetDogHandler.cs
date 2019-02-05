using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace CQRS.Queries
{
    public class GetDogsByBreed : IQuery<IEnumerable<Dog>>
    {
        public string Breed { get; set; }
    }

    public class GetDogHandler : IQueryHandler<GetDogsByBreed, IEnumerable<Dog>>
    {
        private readonly IDbConnection Db;

        public GetDogHandler(IDbConnection db)
        {
            Db = db;
        }

        public IEnumerable<Dog> Handle(GetDogsByBreed query)
        {
            var dogs = new List<Dog>();
            using (var conn = new SqlConnection(Db.ConnectionString))
            using (var c = new SqlCommand("SprocName", conn))
            {
                var transaction = conn.BeginTransaction();
                c.CommandType = CommandType.StoredProcedure;
                
                c.Parameters.Add(new SqlParameter("Breed", query.Breed));

                var dbResult = c.ExecuteReader();
                if (dbResult.HasRows)
                {
                    while (dbResult.Read())
                    {
                        var d = new Dog
                        {
                            Id = (int)dbResult["ColumnName"],
                            Name = (string)dbResult["ColumnName"],
                            Age = (int)dbResult["ColumnName"]
                            //et...
                        };

                        dogs.Add(d);
                    }
                }
            }

            return dogs;
        }
    }
}