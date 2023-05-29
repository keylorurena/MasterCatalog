using MasterCatalog.Models;
using MasterCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterCatalog.Controllers
{
    public class ItemController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            /*List<Drink> drinks = new List<Drink>()
            {
                new Beer() {Name = "Budweiser", IsCarbonated = true, AlcoholPercent = 5, Content="355 ml" },
                new Juice() {Name ="Orange Juice", IsCarbonated = false, FruitMade = "Oranges", Content ="700 ml"},
                new Soda() {Name = "Pepsi", IsCarbonated = true, Flavor = "Cola", Content = "2.5 L"}
            };

            var i = drinks[0].Description;*/

            List<Drink> drinks = DataItemsService.GetDrinks();

            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<Drink> drinks = DataItemsService.GetDrinks();

                return Json(new Response(drinks), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Response("Internal Error", ex.Message, false), JsonRequestBehavior.AllowGet);
            }
        }
    }
}