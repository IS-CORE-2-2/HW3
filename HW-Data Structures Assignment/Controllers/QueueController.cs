using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_Data_Structures_Assignment.Controllers
{
    public class QueueController : Controller
    {
        //static queue for use throughout life of program
        static Queue<string> myQueue = new Queue<string>();
        public ActionResult Index()
        {
            return View();
        }

        //add one entry to the stack
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        //first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” 
        //concatenated with the number. For example, New Entry 1, New Entry 2, New Entry 3. 
        public ActionResult AddLots()
        {
            myQueue.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New Entry " + (iCount + 1));
            }
            return View("Index");
        }

        //display the contents of the data structure. You must use the foreach loop when displaying the data. 
        //Handle any errors and inform the user. NOTE: You can send it back to the Index view or make another view
        public ActionResult Display()
        {
            ViewBag.MyQueue = myQueue;
            return View("Display");
        }

        //delete any item from the structure. Handle any errors and inform the user somewhere on the form if it cannot delete. 
        //HINT: Use the ViewBag
        public ActionResult Delete()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
                ViewBag.DeleteStatus = "Delete successful!";//if an item exists to delete
            }
            else
            {
                ViewBag.DeleteStatus = "Delete unsuccessful. No values existed in the queue.";//if empty
            }
            return View("Delete");
        }

        //wipe out the contents of the data structure
        public ActionResult Clear()
        {
            myQueue.Clear();
            return View("Index");
        }

        //Search for any item in the data structure (hardcoded) and return if it was found or not found and how long it took 
        //to search. You can create a StopWatch object using code like so (just a simple example). Then display the information in
        //the view. You can pass this result back to the view in the ViewBag and display it somewhere on the view
        public ActionResult Search()
        {
            Queue<string> myQueueTemp = new Queue<string>();//temporary queue
            string testValue = "New Entry 54";//random value
            ViewBag.QueueSearchResults = "Item not found.";//"not found" until proven false
            int myCount = myQueue.Count();//initial count of myQueue

            //Stopwatch started
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //loop to find value and put dequeued values  in another queue
            for (int iCount = 0; iCount < myCount; iCount++)
            {
                if (myQueue.Peek() == testValue)
                {
                    ViewBag.QueueSearchResults = "Item " + testValue + " found";
                }
                myQueueTemp.Enqueue(myQueue.Dequeue());
            }

            //stop time
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            ViewBag.StopWatch = ts;

            //put items back in queue
            for (int iCount1 = 0; iCount1 < myCount; iCount1++)
            {
                myQueue.Enqueue(myQueueTemp.Dequeue());
            }

            return View("Search");
        }
    }
}