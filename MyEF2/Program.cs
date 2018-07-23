using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;

namespace MyEF2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext ctx = new MyDbContext())
            {

                //var temp = ctx.Teachers;
                //foreach(var i in temp)
                //{
                //    Console.WriteLine(i.Name);
                //}


                //foreach(var t in temp)
                //{
                //    var cl = ctx.Classes.Where(c => c.Id == t.ClassId).FirstOrDefault();
                //    Console.WriteLine( $"{t.Name}:{cl.Name}");
                //}

                //foreach (var t in temp)
                //{
                //   
                //}

                //Console.WriteLine(ctx.Students.Where(s=>s.Name=="王老师").ToSql());


                // var temp = ctx.Students.Include(s => s.Class).Where(s=> true);

                //var temp = ctx.Students.Join(ctx.Classes, s => s.ClassId, c => c.Id, (s, c) => new
                //{
                //    sName = s.Name,
                //    cName = c.Name
                //});
                //Console.WriteLine(temp.ToSql());

                //foreach(var t in temp)
                //{
                //    Console.WriteLine($"{t.sName}:{t.cName}");
                //}

                //var temp = ctx.Students.GroupBy(s => s.Class);
                //Console.WriteLine(temp.ToSql());
                //foreach(var i in temp)
                //{
                //    foreach(var t in i)
                //    {
                //        Console.WriteLine($"{i.Key.Name}:{t.Name}");
                //    }
                //}

                var temp = ctx.Students.Include(s => s.Class);
                foreach(var t in temp)
                {
                    Console.WriteLine(t.Name+":"+t.Class.Name);
                }
               
            }


            Console.ReadKey();
        }
    }
}
