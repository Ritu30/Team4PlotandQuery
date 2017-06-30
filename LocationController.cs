using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace LocationApp.Controllers
{
    public class LocationController : Controller
    {
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public JsonResult ParseJSONFile(string jsonData)
        {
            try
            {
                jsonData = "[ { 'id':1, 'coordinates':'product name'}, {'id':2, 'coordinates1':'product name 2'}]";

                JsonResult aresult = new JsonResult();
                IDictionary<string, string> aDict = new Dictionary<string, string>(2);
                var objects = JArray.Parse(jsonData); // parse as array  
                foreach (JObject root in objects)
                {
                    foreach (KeyValuePair<String, JToken> app in root)
                    {
                        if (app.Key == "coordinates" || app.Key == "coordinates1")
                        {
                            string value = app.Value.ToString();
                            aDict.Add(app.Key, value);
                        }
                    }
                }
                aresult.Data = JsonConvert.SerializeObject(aDict);
                return aresult;
            }
            catch(Exception e)
            {
                return new JsonResult();
            }
                /*
                 
                [
    {
        "id":1,
        "name":"product name"
    },
    {
        "id":2,
        "name":"product name 2"
    },
    {
        "id":3,
        "name":"product name 3"
    }
]

                 */
            
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
