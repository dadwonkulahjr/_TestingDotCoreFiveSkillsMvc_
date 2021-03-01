using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SimpleApplicationTestingMvcSkills.Models;

namespace SimpleApplicationTestingMvcSkills.Controllers
{
    public class TestMicrosoftDependencyController : Controller
    {
        private IWebHostEnvironment _webHostEnv;
        private IHostEnvironment _hostEnv;
        private IApplicationBuilder _appBuilder;

        public TestMicrosoftDependencyController(IWebHostEnvironment environment,
            IHostEnvironment hostEnvironment, IApplicationBuilder applicationBuilder)
        {
            _webHostEnv = environment;
            _hostEnv = hostEnvironment;
            _appBuilder = applicationBuilder;
        }
        public string Information() { return "Testing All Microsoft Dependency!"; }
        public string RetrievedWebHostInfo()
        {
            string[] data = new string[4];
            data[0] = _webHostEnv.ApplicationName;
            data[1] = _webHostEnv.EnvironmentName;
            data[2] = _webHostEnv.WebRootPath;
            data[3] = _webHostEnv.WebRootFileProvider.GetFileInfo(_webHostEnv.WebRootPath + "Test.txt").Name;
            string result = "";
            result += "Application Name: " + data[0] + "\n";
            result += "Environment Name: " + data[1] + "\n";
            result += "Web Path: " + data[2] + "\n";
            result += "File Path: " + data[3] + "\n";
            return result;
        }
        public JsonResult GetJsonData()
        {
            if (_hostEnv.IsDevelopment())
            {
                return Json(new
                {
                    Text = "Hello World",
                    Info = "My name is Dad S Wonkulah Jr",
                    Favorite = "Progamming is epic!"
                });
            }
            return Json(null);
        }
        public string AppBuilderData()
        {
            return "AppBuilder is on test!";
        }
    }
}
