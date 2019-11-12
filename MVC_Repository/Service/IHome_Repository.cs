using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Model;

namespace MVC_Repository.Service
{
 public   interface IHome_Repository
    {
        List<faculty> GetFacultys();

        List<student> GetStudents();

        void InupStudent(student obj);

        void deleterecord(int Id);
    }
}
