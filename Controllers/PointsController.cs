using Microsoft.AspNetCore.Mvc;
using PUPHubPointsBusinessRules;
using Web.API.Models;

namespace Web.API.Controllers
{
    [Route("api/studentpoints")]
    [ApiController]
    public class PointsController : ControllerBase
    {
        PointsRulesService pointsService;

        public PointsController()
        {
            pointsService = new PointsRulesService();
        }

        [HttpGet]
        public JsonResult GetStudentPoints()
        {
            var studentPoints = pointsService.GetStudentPoints();
            return new JsonResult(studentPoints);
        }

        [HttpGet("{studentnumber}")]
		public JsonResult GetStudentPoints(string studentnumber)
		{
            var studentPoints = pointsService.GetStudentPoint(studentnumber);
            return new JsonResult(studentPoints);
        }

		[HttpPost]
		public bool CreateStudentPoints(StudentPointRequest request)
		{
            return pointsService.CreateStudentPoints(request.StudentNumber, request.Points) > 0;
        }

        [HttpPatch("usepoints")]
        public JsonResult UseStudentPoints(StudentPointRequest request)
        {
            var result = pointsService.UseStudentPoints(request.StudentNumber, request.Points);

            return new JsonResult(result);
        }

		[HttpPatch("addpoints")]
		public JsonResult AddStudentPoints(StudentPointRequest request)
		{
			var result = pointsService.AddStudentPoints(request.StudentNumber, request.Points);

			return new JsonResult(result);
		}
	}
}
