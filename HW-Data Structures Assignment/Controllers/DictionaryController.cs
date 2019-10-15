using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_Data_Structures_Assignment.Controllers
{
    public class DictionaryController : Controller
    {
        //static dictionary for life of program
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();

        //index view
        public ActionResult Index()
        {
            return View();
        }

        //add one entry to the stack
        public ActionResult AddOne()
        {
            myDictionary.Add(myDictionary.Count + 1, "New Entry " + (myDictionary.Count + 1));
            ViewBag.MyDictionary = myDictionary;
            return View("Index");
        }

        //first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” 
        //concatenated with the number.
        public ActionResult AddLots()
        {
            myDictionary.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myDictionary.Add(iCount + 1, "New Entry " + (iCount + 1));
            }
            return View("Index");
        }

        //display the contents of the data structure. You must use the foreach loop when displaying the data. 
        //Handle any errors and inform the user. 
        public ActionResult Display()
        {
            ViewBag.MyDictionary = myDictionary;
            return View("Display");
        }

        //delete any item from the structure. Handle any errors and inform the user somewhere on the form if it cannot delete. 
        public ActionResult Delete()
        {
            if (myDictionary.Count > 0)
            {
                //if an item can be removed
                myDictionary.Remove(0);
                ViewBag.DeleteStatus = "Delete successful!";
            }
            else
            {
                //no items in dictionary
                ViewBag.DeleteStatus = "Delete unsuccessful. No values existed in the queue.";
            }
            return View("Delete");
        }


        //wipe out the contents of the data structure
        public ActionResult Clear()
        {
            myDictionary.Clear();
            return View("Index");
        }

        //Search for any item in the data structure (hardcoded) and return if it was found or not found and how long it took 
        //to search. You can create a StopWatch object using code like so (just a simple example). Then display the information in
        //the view. You can pass this result back to the view in the ViewBag and display it somewhere on the view
        public ActionResult Search()
        {
            int testValue = 54; //hardcoded value
            ViewBag.DictionarySearchResults = "Item not found.";//automatically stores "item not found" until proven false

            //stopwatch declared and started
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            if (myDictionary.ContainsKey(testValue))
            {
                ViewBag.DictionarySearchResults = "Item " + testValue + " found";
            }

            //stopwatch ended
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            return View("Search");
        }
    }
}