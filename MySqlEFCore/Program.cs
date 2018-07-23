using Microsoft.EntityFrameworkCore;
using MySqlEFCore.Models;
using System;
using System.Linq;

namespace MySqlEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                var list = ctx.Students.FirstOrDefault();
                Console.WriteLine(list.Name);
                //var student = new Student { Name="tom2",Age=18, ClassId=3 };
                //ctx.Students.Add(student);
                //ctx.SaveChanges();

                //var list = ctx.Students.ToList();
                //foreach(var i in list)
                //{
                    
                //    Console.WriteLine($"Name={i.Name};age={i.Age};class={i.TClass.Name}");
                //}
                Console.WriteLine("ok");
            }
            Console.ReadKey();
        }
    }
}
