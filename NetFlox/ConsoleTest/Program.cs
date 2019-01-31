using Microsoft.EntityFrameworkCore;
using NetFlox.DAL;
using System;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NetFloxEntities.DbFilePath);
            using (var context = new NetFloxEntities())
            {
                var query = "stan";
                var result = context.Celebrites
                    //.Where(c => c.DateNaissance.HasValue && c.DateNaissance.Value.Year == 1983)
                    .Where(c => EF.Functions.Like(c.Nom, "%" + query + "%"))
                    .OrderByDescending(c => c.RoleCelebriteFilms.Count)
                    .ThenByDescending(c => c.Nom)
                    .Select(c => c.Nom)
                    .ToList();
            }
        }
    }
}
