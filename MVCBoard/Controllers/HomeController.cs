using MVCBoard.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCBoard.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// GET: /Home/GetCalendarData
        /// </summary>
        /// <returns>Return data</returns>
        public ActionResult GetCalendarData()
        {
            // Initialization.
            JsonResult result = new JsonResult();

            try
            {
                // Loading.
                //List<PublicHoliday> data = this.LoadData();

                // Processing.
                result = this.Json(db.PublicHolidays.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Return info.
            return result;
        }



    

        /// <summary>
        /// Load data method.
        /// </summary>
        /// <returns>Returns - Data</returns>
        private List<PublicHoliday> LoadData()
        {
            // Initialization.
            List<PublicHoliday> lst = new List<PublicHoliday>();

            try
            {
                // Initialization.
                string line = string.Empty;
                string srcFilePath = "Content/files/PublicHoliday.txt";
                var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var fullPath = Path.Combine(rootPath, srcFilePath);
                string filePath = new Uri(fullPath).LocalPath;
                StreamReader sr = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read));

                // Read file.
                while ((line = sr.ReadLine()) != null)
                {
                    // Initialization.
                    PublicHoliday infoObj = new PublicHoliday();
                    string[] info = line.Split(',');

                    // Setting.
                    infoObj.Id = Convert.ToInt32(info[0].ToString());
                    infoObj.Title = info[1].ToString();
                    infoObj.Desc = info[2].ToString();
                    infoObj.Start_Date = info[3].ToString();
                    infoObj.End_Date = info[4].ToString();

                    // Adding.
                    lst.Add(infoObj);
                }

                // Closing.
                sr.Dispose();
                sr.Close();
            }
            catch (Exception ex)
            {
                // info.
                Console.Write(ex);
            }

            // info.
            return lst;
        }
    }
}
