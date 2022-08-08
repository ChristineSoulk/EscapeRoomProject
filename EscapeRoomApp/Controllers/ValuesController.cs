using Entities;
using RepositoryServices.Core.Repositories;
using RepositoryServices.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EscapeRoomApp.Controllers
{
   
    public class ValuesController : ApiController  
    {
       

        // GET api/values/5
        [HttpGet]
        public string GetRoomDetails(int? id)
        {
           
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
