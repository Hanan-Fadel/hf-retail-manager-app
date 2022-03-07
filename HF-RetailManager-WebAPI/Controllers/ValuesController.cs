using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace HF_RetailManager_WebAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get()
        {
                    //Get userid of whoever logged in 
             string userId = RequestContext.Principal.Identity.GetUserId();

            return new string[] { "value1", "value2", userId};
        }
        
        //If we want to return http request status code such as 200, 304, ....
        /*
        public IHttpActionResult Get()
        {
            //Get userid of whoever logged in 
            string userId = RequestContext.Principal.Identity.GetUserId();

            return Ok(new string[] { "value1", "value2", userId });
        }*/



        // GET api/values/5
        public string Get(int id)
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
