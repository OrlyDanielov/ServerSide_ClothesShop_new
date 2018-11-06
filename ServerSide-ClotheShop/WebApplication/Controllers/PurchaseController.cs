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
    public class PurchaseController : ApiController
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
        // GET api/<controller>/5
        [Route("api/Purchase/{_id}")]
        public dynamic Get(int _id)
        {
            ClothesShopDBConnection db = new ClothesShopDBConnection();
            List<PurchaseDTO> orders = db.Purchases.Where(x => x.client_id == _id).Select(x => new PurchaseDTO()
            {
                client_id = x.client_id,
                clothe_number = x.clothe_number,
                purchase_date = x.purchase_date,
                amount = x.amount,
                purchase_id = x.purchase_id
            }).ToList();
            return orders;
        }


        /*
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
        */
        [Route("api/Purchase")]
        public HttpResponseMessage Post([FromBody]List<Purchase> purchaces)
        {
            var isSaved = DBQuery.UpdateProductInv_AND_addedPurchase(purchaces);
            //return isSaved ? Request.CreateResponse(HttpStatusCode.OK, isSaved) : Request.CreateResponse(HttpStatusCode.BadRequest, "");
            if (isSaved == true)
                return Request.CreateResponse(HttpStatusCode.OK, isSaved);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "");
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