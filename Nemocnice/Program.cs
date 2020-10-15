using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nemocnice.Data;


/*
 * P�id�na uk�zka pro pr�ci s datab�z�.
 * ------------------------------------
 * �pravy:
 * 14.10.2020 - vytvo�en� �ablony - xsedym02
 */


namespace Nemocnice
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /*
             * TEST
             * new DatabaseContext() - umo��uje pracovat s datab�z�
             */
           // using (var db = new DatabaseContext())
            //{
                /*
                 * Registrace nov�ch tabulek do datab�za. Pouze jednou pro tabulku.
                 * !!! Nejedn� se o p�id�v�n� ��dku do tabulky, to se d�l� jinak.!!!
                 */
                //db.Add(new Table1 { ItemVal_Tab1 = 42 });
                //db.Add(new Table2 { ItemVal_Tab2 = 24 });
               // db.SaveChanges();

                // Test exitence hodnot v datab�zi.
              //  var a = db.Tables1.Where(s => s.Table1Id >= 1).ToList();
              //  var b = db.Tables2.Where(s => s.Table2Id >= 1).ToList();
          //  }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
