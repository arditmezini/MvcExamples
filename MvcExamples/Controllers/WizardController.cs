using MvcExamples.Models.Player;
using MvcExamples.Utils;
using System.Web.Mvc;

namespace MvcExamples.Controllers
{
    public class WizardController : Controller
    {
        [HttpGet]
        public ActionResult PlayerDetails(PlayerDetails playerDetails)
        {
            if (playerDetails.Next != null)
            {
                if (ModelState.IsValid)
                {
                    SessionManager.Save("playerDetails", playerDetails);
                    return View("PlayerStatistics");
                }
            }
            return View("PlayerDetails");
        }

        [HttpGet]
        public ActionResult PlayerStatistics(PlayerStatistics playerStatistics)
        {
            var playerDetails = SessionManager.Get<PlayerDetails>("playerDetails");

            if (playerStatistics.Prev != null)
            {
                return View("PlayerDetails");
            }
            if (playerStatistics.Next != null)
            {
                if (ModelState.IsValid)
                {
                    SessionManager.Save("playerStatistics", playerDetails);
                    return View("PlayerSummary");
                }
            }
            return View("PlayerStatistics");
        }

        [HttpPost]
        public ActionResult PlayerSummary()
        {
            var entity = new PlayerSummary
            {
                PlayerDetails = SessionManager.Get<PlayerDetails>("playerDetails"),
                PlayerStatistics = SessionManager.Get<PlayerStatistics>("playerStatistics")
            };
            //save data

            //clean session
            SessionManager.Remove("playerDetails");
            SessionManager.Remove("playerStatistics");

            return RedirectToAction("PlayerDetails");
        }
    }
}