using Antlr.Runtime.Tree;
using OS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace OS2.Controllers
{
    public class OSController : Controller
    {
        // GET: OS
        [HttpGet]
        public ActionResult Index()
        {
            Process asd = new Process();
            return View(asd);
        }
        [HttpPost]
        public ActionResult Index(Process asd)
        {

            return RedirectToAction("Insert", asd);
        }
        [HttpGet]
        public ActionResult Insert(Process asd)
        {
            if (asd.NumberOfProcess ==0) {

                return RedirectToAction("Index");
            }

            return View(asd);
        }
        [HttpPost]
        public ActionResult Insert(Process asd, int i = 0)
        {
            asd = Order(asd);
            asd = prodata(asd);
            asd.AverageWaitTime=Convert.ToInt32(asd.ProList.Average(s => s.ProcessWaitTime));
            asd.AverageTurnaroundTime=Convert.ToInt32(asd.ProList.Average(s => s.ProcessTurnaround));
            asd.AverageResponseTime=Convert.ToInt32(asd.ProList.Average(s => s.ProcessResponse));
            return View("Result", asd);
            
        }
        public Process prodata(Process asd)
        {
            int s = asd.ProList[0].ProcessArrivalTime;

            foreach (var ele in asd.ProList)
            {
                ele.ProcessWaitTime = s - ele.ProcessArrivalTime;
                ele.ProcessTurnaround = ele.ProcessWaitTime + ele.ProcessBurstTime;
                ele.ProcessResponse = ele.ProcessWaitTime - ele.ProcessArrivalTime;
                s = s + ele.ProcessBurstTime;

            }
            return asd;
        }
        public Process Order(Process asd) {
            List<ProData> temp1 = new List<ProData>();
            List<ProData> temp = new List<ProData>();
            int temp3 = 0;
             asd.ProList = asd.ProList.OrderBy(s => s.ProcessArrivalTime).ToList();

            for (int i = 0; i < asd.ProList.Count;i++)
            {
                temp3 = temp3 + asd.ProList[i].ProcessBurstTime;

                temp = asd.ProList.Where(c => c.ProcessArrivalTime <= temp3).OrderBy(r => r.ProcessPriority).ToList();
               
            }
            temp1= asd.ProList.Where(m => m.ProcessArrivalTime == asd.ProList[0].ProcessArrivalTime).OrderBy(r => r.ProcessPriority).ToList();
            asd.ProList[0] = temp1[0];
            for (int i = 1,s=0 ; s < temp.Count;s++, i++) {
                if (temp[s].ProcessId != asd.ProList[0].ProcessId)
                {
                    asd.ProList[i] = temp[s];

                }
                else { i--; }
            }
                return asd;
        }


        public ActionResult Result(Process asd)
        {


            return View(asd);
        }
     

    }
}