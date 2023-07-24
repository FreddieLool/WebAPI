using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITest.Controllers
{
    public class SetConnectionController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public int Get(int connection, int ID)
        {
            DatabaseManager dbman = new DatabaseManager();
            int result = dbman.SetPlayerConnection(connection, ID);
            return result;
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}