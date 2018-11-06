using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;
using WebApplication.DTO;

namespace WebApplication.Controllers
{
    public class ClientController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /*
          // GET api/<controller>/5
          public string Get(int id)
          {
              return "value";
          }
          */

            // מחפש לקוח לפי תז
    [Route("api/Client/{_id}")]
        public dynamic Get(int _id, [FromBody]string _password)
        {
            try
            {
                ClothesShopDBConnection db = new ClothesShopDBConnection();
                Client c = db.Clients.SingleOrDefault(x => x.id == _id);
                if (c != null )
                {
                    ClientDTO logClient = new ClientDTO()
                    {
                        id = c.id,
                        name = c.name,
                        password = c.password,
                        is_admin = c.is_admin
                    };
                    return logClient;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}