using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using demo0910.Models;


namespace demo0910.Models //可以改長度
{
    [Serializable] //[ser] 
    public class EmpData

    {     //prop tab tab
        public string EmpID { get; set; } //建完就是屬性
        public string EmpName { get; set; }//屬性跟變數的差別，
        public int Age { get; set; }//



        //Initialize 建構式 = 可以有很多個只要 ()裡面不一樣
        //一定是public className ( )不是function, 不是method
        public EmpData (string empid, string empname, int age)
        {
            this.EmpID = empid;
            this.EmpName = empname;
            this.Age = age;

        }
    }


    [Serializable]
    public class UnitData
    {
        public int UnitNO { get; set; }
        public string UnitName { get; set; }
        public int EmployeeID { get; set; }
        public string JobTitle { get; set; }
        public int seniority { get; set; }



        public UnitData(int unitno, string unitname, int employeeid, string jobtitle, int Seniority)
        {
            this.UnitNO = unitno;
            this.UnitName = unitname;
            this.EmployeeID = employeeid;
            this.JobTitle = jobtitle;
            this.seniority = Seniority;

        }
            
   

    }
}