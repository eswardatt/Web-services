using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using emails.Models;

namespace emails.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        EMAILTEMPLATESEntities entities = new EMAILTEMPLATESEntities();
        public ActionResult InsertRegister(EMPLOYEEDETAIL eMPLOYEEDETAIL)
        {
            entities.ASP_INSERT_EMPLOYEEE(eMP_EMPLOYEENAME: eMPLOYEEDETAIL.EMP_EMPLOYEENAME,eMP_EMPLOYEEEMAILID:eMPLOYEEDETAIL.EMP_EMPLOYEEEMAILID, eMP_EMPLOYEEPHONENUMBER: eMPLOYEEDETAIL.EMP_EMPLOYEEPHONENUMBER);
            return View();
        }
    }
}