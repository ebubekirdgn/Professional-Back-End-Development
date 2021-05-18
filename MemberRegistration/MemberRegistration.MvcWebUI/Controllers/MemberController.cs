using MemberRegistration.Entities.Concrete;
using MemberRegistration.MvcWebUI.Models;
using System.Web.Mvc;

namespace MemberRegistration.MvcWebUI.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Add()
        {
            return View(new MemberAddViewModel());
        }

        [HttpPost]
        public ActionResult Add(Member member)
        {
            return View(new MemberAddViewModel());
        }
    }
}