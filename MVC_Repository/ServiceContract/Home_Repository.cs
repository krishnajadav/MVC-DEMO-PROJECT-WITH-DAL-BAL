using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Model;
using MVC_Repository.Service;

namespace MVC_Repository.ServiceContract
{
 public   class Home_Repository : IHome_Repository
    {
        CollegeEntities context = new CollegeEntities();

        public List<faculty> GetFacultys()
        {
            return context.faculties.ToList();
        }

        public List<student> GetStudents()
        {
            return context.students.ToList();
        }

        public void InupStudent(student obj)
        {
            context.InUPStudent(obj.stuid,obj.sfname,obj.slname,obj.semail,obj.smno,obj.sdept,obj.fid,obj.spass);
        }

        public void deleterecord(int Id)
        {
            var alldata = GetStudents();
            var data = alldata.Where(x => x.stuid == Id).FirstOrDefault();
            context.students.Remove(data);
            context.SaveChanges();
        }
    }
}
