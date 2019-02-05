using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Collections.Generic;

using CQRS.Queries;

namespace CQRS.Commands
{
    public class SaveDog : ICommand
    {
        public Dog Dog { get; set; }
    }

    public class SaveDogHandler : ICommandHandler<SaveDog>
    {
        private readonly IDbConnection Db;
        public IQueryHandler<GetDogsByBreed, IEnumerable<Dog>> GetDogsQuery { get; set; }

        public SaveDogHandler(
            IDbConnection db,
            IQueryHandler<GetDogsByBreed, IEnumerable<Dog>> getDogQuery)
        {
            Db = db;
            GetDogsQuery = getDogQuery;
        }

        public void Handle(SaveDog command)
        {
            //some sort of query regarding the thing we want to save, not intended to be realistic
            var dog = command.Dog;
            var dbDog = GetDogsQuery.Handle(new GetDogsByBreed { Breed = dog.Breed }).First();
            dog.Id = dbDog.Id;
            
            using (var conn = new SqlConnection(Db.ConnectionString))
            using (var c = new SqlCommand("SprocName", conn))
            {
                var transaction = conn.BeginTransaction();
                c.CommandType = CommandType.StoredProcedure;

                c.Parameters.Add(new SqlParameter("Id", dog.Id));
                c.Parameters.Add(new SqlParameter("Name", dog.Name));
                c.Parameters.Add(new SqlParameter("Age", dog.Age));
                c.Parameters.Add(new SqlParameter("Breed", dog.Breed));

                var result = c.ExecuteNonQueryAsync();

                //maybe also update our dog object with the id/values etc
            }
        }
    }
}