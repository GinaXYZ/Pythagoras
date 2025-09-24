using Microsoft.AspNetCore.Mvc;

namespace Pythagoras.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(double? KatheteA, double? KatheteB, double? Hypotenuse)
        {

            ViewBag.KatheteA = KatheteA;
            ViewBag.KatheteB = KatheteB;
            ViewBag.Hypotenuse = Hypotenuse;


            string Fehlermeldung = "";
            int wasIstZuTun = 0;
            if (KatheteA is not null) wasIstZuTun += 1;
            if (KatheteB is not null) wasIstZuTun += 2;
            if (Hypotenuse is not null) wasIstZuTun += 4;

            if (Hypotenuse < KatheteA || Hypotenuse < KatheteB)
            {
                wasIstZuTun = 8;
            }

            switch (wasIstZuTun)
            {
                case 0:
                    Fehlermeldung = "Bitte mindestens zwei Seitenlängen angeben.";
                    break;
                case 1:
                    Fehlermeldung = "Bitte mindestens zwei Seitenlängen angeben.";
                    break;
                case 2:
                    Fehlermeldung = "Bitte mindestens zwei Seitenlängen angeben.";
                    break;
                case 3:
                    Hypotenuse = Math.Sqrt((double)((KatheteA * KatheteA) + (KatheteB * KatheteB)));
                    break;
                case 4:
                    Fehlermeldung = "Bitte mindestens zwei Seitenlängen angeben.";
                    break;
                case 5:
                    KatheteB = Math.Sqrt((double)(Hypotenuse * Hypotenuse - KatheteA * KatheteA));
                    break;
                    case 6:
                    KatheteA = Math.Sqrt((double)(Hypotenuse * Hypotenuse - KatheteB * KatheteB));
                    break;
                    case 7:
                    Fehlermeldung = "Es sind bereits alle Seitenlängen angegeben.";
                    break;
                    case 8:
                    Fehlermeldung = "Die Hypotenuse muss die längste Seite sein.";
                    break;

            }
            ViewBag.Fehlermeldung = Fehlermeldung;
            return View();
        }
    }
}
