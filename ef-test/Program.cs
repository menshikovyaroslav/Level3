using ef_test.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string connString = @"Data Source=DESKTOP-0NQABKF\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True";

            using (var db = new StudentsDb(new DbContextOptionsBuilder<StudentsDb>().UseSqlServer(connString).Options))
            {
           //     await db.Database.EnsureCreatedAsync();

                //var count = await db.Students.CountAsync();

                //Console.WriteLine($"count={count}");
            }

            using (var db = new StudentsDb(new DbContextOptionsBuilder<StudentsDb>().UseSqlServer(connString).Options))
            {
                await db.Database.MigrateAsync();

                var students = await db.Students.Include(s=>s.Group).Where(s=>s.Group.Name.EndsWith("2")).ToArrayAsync();

                foreach (var student in students)
                {
                    Console.WriteLine($"id={student.Id}, groupname={student.Group.Name}");
                }


                var count = await db.Students.CountAsync();
                //if (count == 0)
                //{
                //    for (int i = 0; i < 5; i++)
                //    {
                //        var group = new Group()
                //        {
                //        //    Description = $"Description {i}",
                //            Name = $"Name {i}",
                //            Students = new List<Student>()
                //        };

                //        for (int j = 0; j < 5; j++)
                //        {
                //            var student = new Student()
                //            {
                //                Name = $"Name {j}",
                //                SurName = $"SurName {j}",
                //                Family = $"Family {j}",
                //                Group = group
                //            };

                //            group.Students.Add(student);
                //        }

                //        db.Groups.Add(group);
                //    }
                //}

                await db.SaveChangesAsync();

                count = await db.Students.CountAsync();
                Console.WriteLine($"count={count}");
            }

            Console.ReadLine();
        }
    }
}
