using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{
    public partial class Classes
    {



           public string TeacherName
           {
               get
               {
                   if (!TeacherId.HasValue)
                   {
                       return "";
                   }

                   CourseManagerEntities1 db = new CourseManagerEntities1();
                   var teacher = db.Teachers.Where(t => t.Id == TeacherId.Value).FirstOrDefault();
                   if (teacher == null) {
                       return "";
                   }
                   return teacher.Name;
               }
           }

    }
}