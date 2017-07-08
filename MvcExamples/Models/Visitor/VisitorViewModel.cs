using System.Collections.Generic;

namespace MvcExamples.Models.Visitor
{
    public class VisitorViewModel
    {
        public VisitorSearchForm VisitorSearchForm { get; set; }
        public List<VisitorDto> VisitorList { get; set; }
    }
}