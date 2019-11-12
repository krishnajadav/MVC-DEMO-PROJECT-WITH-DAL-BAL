using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Repository.Service;
using MVC_Repository.ServiceContract;
using MVC_Model;

namespace MVC_Pattern.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

       IHome_Repository Ihome = new Home_Repository(); 
 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            if(Session.Count>0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

           
        }


        public JsonResult CheckFacultyDetails(string email,string fpass)
        {

             List<faculty> fdata=Ihome.GetFacultys();


            var result = from c in fdata where c.femail == email && c.fpass == fpass select c;

            if (result != null && result.Count() > 0)
            {

                foreach (var c in result)
                {
                    Session["Uname"] = c.fname;
                    Session["Uid"] = c.fid;
                    Session["dept"] = c.fdept;

                }
               
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }




        public JsonResult checkStudentDetail(string email,string mno,string fname,string lname)
        {
            List<student> sdata = Ihome.GetStudents();


            var result = from c in sdata  where (c.semail == email || c.smno == mno) select c;

            if (result == null || result.Count() > 0)
            {

                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }


        }


        public JsonResult InupStudent(string Id,string fname,string lname, string email, string mno, string spass)
        {

            try
            {

                student obj=new student();

                obj.stuid = Convert.ToInt32(Id);
                obj.sfname = fname;
                obj.slname = lname;
                obj.semail = email;
                obj.smno = mno;
                obj.spass = spass;
                obj.sdept = Session["dept"].ToString();
                obj.fid =Convert.ToInt32(Session["Uid"].ToString());


                Ihome.InupStudent(obj);

                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }




        public JsonResult GetStudentData()
        {
            var alldata = Ihome.GetStudents();

            var result = from x in alldata where x.fid==Convert.ToInt32(Session["Uid"].ToString())
                         select new[]
                         {
                                Convert.ToString(x.stuid),
                                Convert.ToString(x.sfname),
                                Convert.ToString(x.slname),
                                Convert.ToString(x.semail),
                                Convert.ToString(x.smno),
                                Convert.ToString(x.spass)

                         };

            return Json(new
            {
                aaData = result
            },
          JsonRequestBehavior.AllowGet);
        }


        public JsonResult deleteRecord(int ID)
        {
            try
            {
               Ihome.deleterecord(ID);

                return Json(1, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }


        public JsonResult checkUpdate(string upmno, string upemail,string email,string mno)
        {
            List<student> sdata = Ihome.GetStudents();


            if(upmno==mno && upemail==email)
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else if(email!=upemail && mno==upmno)
            {
                var result = from c in sdata where (c.semail == email) select c;
                if (result.Count() > 0)
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            else if(email == upemail && mno != upmno)
            {
                var result= from c in sdata where (c.smno == mno) select c;
                if (result.Count() > 0)
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }

            else
            {
                var result = from c in sdata where (c.semail == email || c.smno == mno) select c;

                if (result == null || result.Count() > 0)
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
        
        }

    }
}