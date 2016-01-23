using System.Collections.Generic;
using System.Web.Http;
using RockBandsWebApi.Models;
using RockBandsWebApi.Repository;

namespace RockBandsWebApi.Controllers
{
    public class RockBandsController : ApiController
    {
       
        public IEnumerable<RockBand> Get()
        {
            InMemoryDatabaseObjectContext repository = InMemoryDatabaseObjectContext.Instance;

            return repository.GetAll();
        }
    }
}