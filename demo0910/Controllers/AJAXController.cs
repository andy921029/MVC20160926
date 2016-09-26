using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo0910.Models;

namespace demo0910.Controllers
{
    public class AJAXController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }
        public PartialViewResult showData(string empid = "")
        {

            databaseEntities objEmpList = new databaseEntities();
            EmpViewModel Emplist = new EmpViewModel();

            var emplist = (from E in objEmpList.EmployeeData
                           join U in objEmpList.UnitTable on E.EmployeeID equals U.EmployeeID
                           select new EmpViewModel
                           {
                               EmployeeID = E.EmployeeID,
                               EmployeeName = E.EmployeeName,
                               Gender = E.Gender,
                               Birthday = E.Birthday,
                               CreateDate = E.CreateDate,
                               LastLoginDate = E.LastLoginDate,
                               UnitNO = U.UnitNO,
                               UnitName = U.UnitName,
                               JobTitle = U.JobTitle,
                               seniority = U.seniority
                           }).ToList();
            if (!string.IsNullOrWhiteSpace(empid))
            {
                emplist = emplist.Where(x => x.EmployeeID == int.Parse(empid)).ToList();

            }
            return PartialView(emplist);

        }



        public ActionResult Add(EmpViewModel objemp)
        {

            {
                using (databaseEntities db = new databaseEntities())
                {
                    db.SaveChanges();
                }
                return View();
            }
        }


        public ActionResult AddData(EmployeeData empdata, UnitTable unitdata)
        {
            using (databaseEntities db = new databaseEntities())
            {
                EmpViewModel data = new EmpViewModel();
                db.EmployeeData.Add(empdata);
                db.UnitTable.Add(unitdata);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }




        public ActionResult Edit(string EmployeeID)
        {
            using (databaseEntities objEmpList = new databaseEntities())
            {
                {
                    //宣告
                    EmpViewModel VMlist = new EmpViewModel();
                    var emplist = (from E in objEmpList.EmployeeData
                                   join U in objEmpList.UnitTable on E.EmployeeID equals U.EmployeeID
                                   select new EmpViewModel
                                   {
                                       EmployeeID = E.EmployeeID,
                                       EmployeeName = E.EmployeeName,
                                       Gender = E.Gender,
                                       Birthday = E.Birthday,
                                       CreateDate = E.CreateDate,
                                       LastLoginDate = E.LastLoginDate,
                                       UnitNO = U.UnitNO,
                                       UnitName = U.UnitName,
                                       JobTitle = U.JobTitle,
                                       seniority = U.seniority
                                   }).ToList();
                    //查詢篩選條件
                    VMlist = emplist.Where(x => x.EmployeeID == int.Parse(EmployeeID)).FirstOrDefault();
                    objEmpList.SaveChanges();
                    return View(VMlist);

                }
            }
        }

        //儲存修改結果到EmpViewModel
        public ActionResult EditSav(EmpViewModel getdata)
        {
            using (databaseEntities db = new databaseEntities())
            {
                if (ModelState.IsValid)
                {
                    EmployeeData Emdata = db.EmployeeData.Where(x => x.EmployeeID == getdata.EmployeeID).FirstOrDefault();

                    Emdata.EmployeeID = getdata.EmployeeID;
                    Emdata.EmployeeName = getdata.EmployeeName;
                    Emdata.Gender = getdata.Gender;
                    Emdata.Birthday = getdata.Birthday;
                    Emdata.CreateDate = getdata.CreateDate;
                    Emdata.LastLoginDate = getdata.LastLoginDate;

                    UnitTable unitdata = db.UnitTable.Where(y => y.EmployeeID == getdata.EmployeeID).FirstOrDefault();
                    unitdata.UnitNO = getdata.UnitNO;
                    unitdata.UnitName = getdata.UnitName;
                    unitdata.JobTitle = getdata.JobTitle;
                    unitdata.seniority = getdata.seniority;

                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

       
    }
}