using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_PROJECT.Models;
using TEST_PROJECT.DB;

namespace TEST_PROJECT.Controllers
{
    public class Test3Controller : Controller
    {
        private BusinessLayer rule;

        private TestEntities context = new TestEntities();

        public Test3Controller()
        {
            rule = new BusinessLayer(new TestEntities());
        }

        //Add Person

        public ActionResult Index()
        {         
            return View();
        }

        public JsonResult CreatePerson(Person person)
        {
            return Json(rule.CreatePerson(person), JsonRequestBehavior.AllowGet);
        }

        //Get Person

        public ActionResult ShowPerson()
        {
            return View(rule.GetPerson().ToList());
        }

        public ActionResult Test()
        {
            return View(rule.GetPerson().ToList());
        }

        public ActionResult EditPerson(int PersonID)
        {
            var PData = rule.GetPersonById(PersonID);
            return View(PData);
        }


        public JsonResult Edit(Person person)
        {
            return Json(rule.UpdatePerson(person), JsonRequestBehavior.AllowGet);
        }


        public ActionResult DeletePerson(int PersonID)
        {
            rule.DeletePerson(PersonID);
            return RedirectToAction("Test");  
        }

        public ActionResult TestPage()
        {
            return View();
        }

        public JsonResult GetCustomerType() 
        {
            var CusData = context.usp_GetCustomerType().ToList();
            return Json(CusData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCategoryType()
        {
            var CatData = context.usp_GetCategoryType().ToList();
            return Json(CatData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGadgets(int CategoryID)
        {
            var GadData = context.usp_GetGadgetsByCategoryID(CategoryID).ToList();
            return Json(GadData, JsonRequestBehavior.AllowGet);
        }
 
        public ActionResult AddCustomerType()
        {
            return View();
        }

        public JsonResult CreateCustomerType(string CustomerType)
        {
            return Json(rule.CreateCustomerType(CustomerType), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCategoryType()
        {
            return View();
        }

        public JsonResult CreateCategoryType(string CategoryType)
        {
            return Json(rule.CreateCategoryType(CategoryType), JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddGadgets()
        {
            List<SelectListItem> CategoryType = new List<SelectListItem>();

            foreach (var item in context.usp_GetCategoryType())
            {
                SelectListItem temp = new SelectListItem() { Text = item.CategoryType, Value = item.CategoryID.ToString(), Selected = true };
                CategoryType.Add(temp);
            }

            ViewBag.CheckBoxList = CategoryType;

            return View();
        }

        public JsonResult CreateGadgets(string GadgetName, decimal Price, int CategoryID)
        {
            return Json(rule.CreateGadgets(GadgetName,Price,CategoryID), JsonRequestBehavior.AllowGet);
        }

    }
}
