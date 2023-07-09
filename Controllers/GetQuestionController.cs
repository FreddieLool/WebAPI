using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPITest.Controllers
{
    public class GetQuestionController : ApiController
    {
        // GET api/<controller>/5
        public Question Get(int id)
        {
            DatabaseManager dbman = new DatabaseManager();
            Question result = dbman.GetQuestion(id);
            return result;
        }
    }
}