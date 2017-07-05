using System.Web.Http;

namespace AssetAPI.Controllers
{
    public class PurchaseController : ApiController
    {
        // GET: Add To Cart
        [HttpPost]
        public IHttpActionResult AddToCart()
        {
            return Ok("Added To Cart");
        }
    }
}