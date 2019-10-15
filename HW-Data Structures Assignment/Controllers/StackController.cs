using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_Data_Structures_Assignment.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        // GET: Stack
        public ActionResult Index()
        {
            return View();
        }

        //add one entry to the stack
        public ActionResult AddOne()
        {
            myStack.Push("New Entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;
            return View("Index");
        }

        //first clears the data structure and then generate 2,000 items in the data structure with the value of “New Entry” 
        //concatenated with the number. For example, New Entry 1, New Entry 2, New Entry 3. 
        public ActionResult AddLots()
        {
            myStack.Clear();
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myStack.Push("New Entry " + (iCount + 1));
            }
            return View("Index");
        }

        //display the contents of the data structure. You must use the foreach loop when displaying the data. 
        //Handle any errors and inform the user. NOTE: You can send it back to the Index view or make another view
        public ActionResult Display()
        {
            ViewBag.MyStack = myStack;
            return View("Display");
        }

        //delete any item from the structure. Handle any errors and inform the user somewhere on the form if it cannot delete. 
        //HINT: Use the ViewBag
        public ActionResult Delete()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
                ViewBag.DeleteStatus = "Delete successful!";
            }
            else
            {
                ViewBag.DeleteStatus = "Delete unsuccessful. No values existed in the stack.";
            }
            return View("Delete");
        }

        //wipe out the contents of the data structure
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Index");
        }

        //Search for any item in the data structure (hardcoded) and return if it was found or not found and how long it took 
        //to search. You can create a StopWatch object using code like so (just a simple example). Then display the information in
        //the view. You can pass this result back to the view in the ViewBag and display it somewhere on the view
        public ActionResult Search()
        {
            Stack<string> myStackTemp = new Stack<string>();
            string testValue = "New Entry 54";
            ViewBag.StackSearchResults = "Item not found.";
            int myCount = myStack.Count();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();

            for (int iCount = 0; iCount < myCount; iCount++)
            {
                if (myStack.Peek() == testValue)
                {
                    ViewBag.StackSearchResults = "Item " + testValue + " found";
                }
                myStackTemp.Push(myStack.Pop());
            }

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;

            for (int iCount1 = 0; iCount1 < myCount; iCount1++)
            {
                myStack.Push(myStackTemp.Pop());
            }

            return View("Search");
        }
    }
}