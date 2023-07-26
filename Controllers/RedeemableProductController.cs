using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUPHubPointsBusinessRules;
using PUPHubPointsModels;

namespace Web.API.Controllers
{
    [Route("api/redeemableproducts")]
    [ApiController]
    public class RedeemableProductController : ControllerBase
    {
        RedeemableProductRulesService rulesService;

        public RedeemableProductController()
        {
            rulesService = new RedeemableProductRulesService();
        }

        [HttpGet]
        public JsonResult GetRedeemableServices()
        {
            var services = rulesService.GetProducts();

            return new JsonResult(services);
        }

        [HttpGet("{productname}")]
        public JsonResult GetRedeemableService(string productname)
        {
            var service = rulesService.GetProduct(productname);
            return new JsonResult(service);
        }

        [HttpPost]
        public bool AddService(RedeemableProduct redeemableProduct)
        {
            return rulesService.AddProduct(redeemableProduct) > 0;
        }

        [HttpPatch]
        public bool UpdateService(RedeemableProduct redeemableProduct)
        {
            return rulesService.UpdateProduct(redeemableProduct) > 0;
        }

        [HttpDelete]
        public void DeleteService(RedeemableProduct redeemableProduct)
        {
            rulesService.DeleteProduct(redeemableProduct);
        }
    }
}
