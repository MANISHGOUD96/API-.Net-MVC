using MK_API_WebMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MK_API_WebMVC.Controllers
{
    public class HomeController : Controller
    {
        //---------------Read the table Data---------------------
        public ActionResult Index()
        {
            
          //...........1st step...........
            HttpClient client = new HttpClient();

            //...........2nd step...........
            var data =client.GetAsync("http://localhost:62369/Api/GetEMPData").Result;

            //...........3rd step...........
            var readdata = data.Content.ReadAsStringAsync().Result;

            //.....4th Convert JSON to Class.......... 
            var empres=JsonConvert.DeserializeObject<List<EmpModel>>(readdata);

            return View(empres);
        }

        //---------------Add Data in Table---------------------

        [HttpGet]
        public ActionResult AddEmp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddEmp(EmpModel obj)
        {
            //...........1st step...........
            HttpClient client = new HttpClient();
            var data = JsonConvert.SerializeObject(obj);
            StringContent postdata = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var result = client.PostAsync("http://localhost:62369/Api/SaveData", postdata).Result;
            return RedirectToAction("Index");
        }

        //---------------Delete Data from Table---------------------
        public ActionResult Delete(int Id)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:62369/Api/DeleteData" + "?Id=" + Id).Result;
            return RedirectToAction("Index");
        }

        //---------------Edit Data from Table---------------------
        public ActionResult Edit(int Id)
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("http://localhost:62369/Api/EditData" + "?Id=" + Id).Result;

            var data = result.Content.ReadAsStringAsync().Result;
            var objdata = JsonConvert.DeserializeObject<EmpModel>(data);
            return View("AddEmp", objdata);
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
    }
}