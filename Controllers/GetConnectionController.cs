using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITest.Controllers
{
    public class GetConnectionController : ApiController
    {
        // GET api/ConnectedPlayer
        public IEnumerable<int> Get()
        {
            return new int[] { 4, 85, 7 };
        }

        // GET api/ConnectedPlayer/5
        public int Get(int id)
        {
            DatabaseManager dbman = new DatabaseManager();
            int playerConnection = dbman.GetPlayerConnection(id);
            return playerConnection;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}