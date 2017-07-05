using AssetAPI.Models;
using System.Web.Http;

namespace AssetAPI.Controllers
{
    /// <summary>
    /// Assets Controller
    /// </summary>
    public class AssetsController : ApiController
    {
        /// <summary>
        /// Get the Assets
        /// </summary>
        /// <returns></returns>
        public IHttpActionResult GetAssets()
        {
            ProductList planlist = new ProductListCreator().GetProductList("ProductCatalog");

            if (planlist == null)
            {
                return NotFound();
            }

            return (Ok(planlist));
        }


    }
}
