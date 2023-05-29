using MasterCatalog.Models;
using MasterCatalog.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MasterCatalog.Controllers
{
    public class DescriptionSettingsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                List<DescriptionSettingsItem> descriptionSettings = DescriptionSettingsService.GetDescriptionSettings().Data;

                return Json(new Response(descriptionSettings), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Response("Internal Error", ex.Message, false), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Save(DescriptionSettingsItem descriptionSettingsItem)
        {
            try
            {
                (bool, string) result = DescriptionSettingsService.SaveSettings(descriptionSettingsItem);

                if (result.Item1)
                {
                    return Json(new Response(result.Item2), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new Response(result.Item2, "Record not updated", false), JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new Response("Internal Error", ex.Message, false), JsonRequestBehavior.AllowGet);
            }
        }
    }
}