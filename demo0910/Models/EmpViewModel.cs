using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using demo0910.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace demo0910.Models
{
    

    [Serializable]
    public class EmpViewModel
    {
      
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Employee name is required")]
        public string EmployeeName { get; set; }
        public string Gender { get; set; }
        [RegularExpression(@"^(19|20|21)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "日期格式錯誤")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Birthday { get; set; }

        [RegularExpression(@"^(19|20|21)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "日期格式錯誤")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [RegularExpression(@"^(19|20|21)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "日期格式錯誤")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime LastLoginDate { get; set; }
        [Required(ErrorMessage = "UnitNO is required")]
        public int UnitNO { get; set; }
        public string UnitName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Must have a minimum length of 2")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "seniority is required")]
        public int seniority { get; set; }


    }

    //[Serializable]
    //public class EmpData
    //{

    //    public List<EmpData> EmpList;
    //    public bool IsSuccess { get; set; }
    //    public string Msg { get; set; }

    //    public EmpData()
    //    {
    //        EmpList = new List<EmpData>();
    //    }
    //}
}