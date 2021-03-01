using Microsoft.AspNetCore.Mvc;

namespace SimpleApplicationTestingMvcSkills.Controllers
{
    public class ProcessController : Controller
    {
        public ProcessController()
        {

        }
        public JsonResult Data()
        {
            return Json(new { name = "iamtuse", occupation = "Developer", education = "Bsc IT" });
        }
        public string Greeting()
        {
            return "Good Morning from Process Controller!";
        }
    }
}
