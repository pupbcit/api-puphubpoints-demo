using Microsoft.AspNetCore.Mvc;
using PUPHubModels;
using PUPHubPointsBusinessRules;

namespace Web.API.Controllers
{
	[Route("api/students")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		StudentRulesService studentService;
        public StudentsController()
        {
			studentService = new StudentRulesService();    
        }

        [HttpGet("{studentnumber}")]
		public JsonResult GetStudentPoints(string studentnumber)
		{
			var test = studentService.GetStudent(studentnumber);
			return new JsonResult(test);
		}

		[HttpPost]
		public void CreateStudent(Student student)
		{
			studentService.CreateStudent(student);
		}
	}
}
