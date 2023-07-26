using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PUPHubPointsBusinessRules;
using PUPHubPointsModels;

namespace Web.API.Controllers
{
    [Route("api/redeemableservices")]
    [ApiController]
    public class RedeemableServiceController : ControllerBase
    {
        RedeemableServicesRulesService rulesService;

        public RedeemableServiceController()
        {
            rulesService = new RedeemableServicesRulesService();
        }

        [HttpGet]
        public JsonResult GetRedeemableServices()
        {
            var services = rulesService.GetServices();

            return new JsonResult(services);
        }

        [HttpGet("{servicename}")]
        public JsonResult GetRedeemableService(string servicename)
        {
            var service = rulesService.GetService(servicename);
            return new JsonResult(service);
        }

        [HttpPost]
        public bool AddService(RedeemableService redeemableService)
        {
            return rulesService.AddService(redeemableService) > 0;
        }

        [HttpPatch]
        public bool UpdateService(RedeemableService redeemableService)
        {
            return rulesService.UpdateService(redeemableService) > 0;
        }

        [HttpDelete]
        public void DeleteService(RedeemableService redeemableService)
        {
            rulesService.DeleteService(redeemableService);
        }
    }
}
