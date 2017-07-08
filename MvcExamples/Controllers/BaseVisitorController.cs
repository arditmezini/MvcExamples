using MvcExamples.Models.Visitor;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MvcExamples.Controllers
{
    public class BaseVisitorController : Controller
    {
        private readonly string jsonPath = AppDomain.CurrentDomain.BaseDirectory + "App_Data\\visitor-mock.json";

        public IQueryable<VisitorDto> visitorList;

        public BaseVisitorController()
        {
            var visitorObject = System.IO.File.ReadAllText(jsonPath);
            visitorList = JsonConvert.DeserializeObject<List<VisitorDto>>(visitorObject).AsQueryable();
        }
    }
}
