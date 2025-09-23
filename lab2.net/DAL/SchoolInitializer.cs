using lab2.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace lab2.net.DAL
{
    public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext ctx)
        {
            var students = new List<Student> {
                new Student{FirstMidName="Thịnh", LastName="Đỗ", EnrollmentDate=new DateTime(2025,9,3)},
                new Student{FirstMidName="An", LastName="Trần", EnrollmentDate=new DateTime(2025,9,5)},
                new Student{FirstMidName="Bình", LastName="Lê", EnrollmentDate=new DateTime(2025,9,6)},
                new Student{FirstMidName="Châu", LastName="Phạm", EnrollmentDate=new DateTime(2025,9,7)},
                new Student{FirstMidName="Dũng", LastName="Võ", EnrollmentDate=new DateTime(2025,9,8)},
                new Student{FirstMidName="Huy", LastName="Đỗ", EnrollmentDate=new DateTime(2025,9,9)},
                new Student{FirstMidName="Lan", LastName="Phan", EnrollmentDate=new DateTime(2025,9,10)},
                new Student{FirstMidName="Mai", LastName="Bùi", EnrollmentDate=new DateTime(2025,9,11)},
                new Student{FirstMidName="Nam", LastName="Hoàng", EnrollmentDate=new DateTime(2025,9,12)},
                new Student{FirstMidName="Oanh", LastName="Đinh", EnrollmentDate=new DateTime(2025,9,13)},
                new Student{FirstMidName="Phúc", LastName="Trương", EnrollmentDate=new DateTime(2025,9,14)},
                new Student{FirstMidName="Quân", LastName="Ngô", EnrollmentDate=new DateTime(2025,9,15)},
                new Student{FirstMidName="Trang", LastName="Lưu", EnrollmentDate=new DateTime(2025,9,16)},
                new Student{FirstMidName="Vy", LastName="Hồ", EnrollmentDate=new DateTime(2025,9,17)},
                new Student{FirstMidName="Yến", LastName="Tạ", EnrollmentDate=new DateTime(2025,9,18)},
                new Student{FirstMidName="Khoa", LastName="Huỳnh", EnrollmentDate=new DateTime(2025,9,19)},
                new Student{FirstMidName="Minh", LastName="Tô", EnrollmentDate=new DateTime(2025,9,20)},
                new Student{FirstMidName="Nhi", LastName="Dương", EnrollmentDate=new DateTime(2025,9,21)},
                new Student{FirstMidName="Phát", LastName="Kiều", EnrollmentDate=new DateTime(2025,9,22)},
                new Student{FirstMidName="Sơn", LastName="Vương", EnrollmentDate=new DateTime(2025,9,23)},
            };
            students.ForEach(s => ctx.Students.Add(s));
            ctx.SaveChanges();
        }
    }
}