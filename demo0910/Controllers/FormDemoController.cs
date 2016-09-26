using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demo0910.Models;

namespace demo0910.Controllers
{
    public class FormDemoController : Controller
    {
        /// <summary>
        /// 使用ACTION RESULT 把VIEWMODEL裡的資料 傳到VIEW
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public ActionResult Index(string empid = "")
        {
            
                //宣告
     
                databaseEntities objEmpList = new databaseEntities();
               
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
            return View(emplist);
        }


        /// <summary>
        /// 使用PARTIAL VIEW 把VIEWMODEL裡的資料 顯示在VIEW
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public PartialViewResult showData(string empid)
        {

               //宣告
                databaseEntities objEmpList = new databaseEntities();
               
                //JOIN 員工表和單位表
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
           
          
           
            //結果傳到VIEW
            return PartialView(emplist);     
          }

        public ActionResult Edit2(string EmployeeID)
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

        //儲存修改結果到ViewModel
        public ActionResult EditSave(EmpViewModel getdata)
        {
        try { 
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
                    return RedirectToAction("Index");
                }
           
             }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                ViewBag.Message = "Sorry, that didn't work!<br />Andy beat you to the punch";
                return View();

            }
        }




        public ActionResult Insert()
        {
            using (databaseEntities db = new databaseEntities())
            {
                EmpViewModel empInsert = new EmpViewModel();
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult InsertData(EmployeeData empdata, UnitTable unitdata)
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

        // 放置自我介紹內容的頁面

        public ActionResult About()
        {
            ViewBag.Message = "Your About page.";
            return View();
        }


    

            public ActionResult Delete(string EmployeeID)
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


        // POST: PersonalDetails/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(EmployeeData empdata, UnitTable unitdata)
        {
            using (databaseEntities db = new databaseEntities())
            {
                EmpViewModel data = new EmpViewModel();
                
                db.EmployeeData.Attach(empdata);
                db.EmployeeData.Remove(empdata);
                db.UnitTable.Attach(unitdata);
                db.UnitTable.Remove(unitdata);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}