using MvcExamples.Models.Visitor;
using System.Linq;
using System.Web.Mvc;
using MvcExamples.Context;

namespace MvcExamples.Controllers
{
    public class VisitorController : Controller
    {
        private readonly MvcContext _context;

        public VisitorController()
        {
            _context = new MvcContext();
        }

        public ActionResult Index(VisitorSearchForm searchModel)
        {
            var visitorList = _context.Visitor
                .Where(x => searchModel.FirstName == null || x.FirstName.Contains(searchModel.FirstName))
                .Where(x => searchModel.LastName == null || x.LastName.Contains(searchModel.LastName))
                .Where(x => searchModel.Email == null || x.Email.Contains(searchModel.Email))
                .Where(x => searchModel.Gender == null || x.Gender.Contains(searchModel.Gender));

            var visitorViewModel = new VisitorViewModel
            {
                VisitorSearchForm = new VisitorSearchForm(),
                VisitorList = visitorList.ToList()
            };

            return View(visitorViewModel);
        }

        public ActionResult Detail(int id)
        {
            if (id != 0)
            {
                var entitiy = _context.Visitor.FirstOrDefault(x => x.Id == id);
                return View(entitiy);
            }
            return RedirectToAction("Index");
        }
    }
}