using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiveUpdate.Models;
using SignalR.Hubs;
using SignalR;

namespace LiveUpdate.Controllers
{
    public class LiveUpdateController : Controller
    {
        /// <summary>
        /// Gets or sets the Application-stored copy of the update list.
        /// </summary>
        /// <value>
        /// The update list.
        /// </value>
        public List<Update> UpdateList
        {
            get
            {
                return HttpContext.Application["UpdateList"] as List<Update>;
            }
            set 
            {
                HttpContext.Application["UpdateList"] = value;
            }
        }

        //
        // GET: /LiveUpdate/

        public ActionResult Index()
        {
            return View(UpdateList.OrderByDescending(m => m.PublishDate));
        }

        //
        // GET: /LiveUpdate/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /LiveUpdate/Create

        /// <summary>
        /// Creates the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // Process the form
                Utilities.UpdateType type = Utilities.UpdateType.News;

                if(string.Compare(collection["UpdateType"], Utilities.UpdateType.Event.ToString()) == 0)
                {
                    type = Utilities.UpdateType.Event;
                }
                else if(string.Compare(collection["UpdateType"], Utilities.UpdateType.News.ToString()) == 0)
                { 
                    type = Utilities.UpdateType.News;
                }

                // Create update to be sent to the client
                Update update = new Update() { Name = collection["Name"], UpdateType = type.ToString(), PublishDate = DateTime.Now };

                UpdateList.Add(update);

                BroadcastUpdate(update);

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Broadcasts the update to all connected clients. I've done this directly in the controller to 
        /// demonstrate server -> client pushing, rather than client -> client pushing.
        /// </summary>
        /// <param name="updateItem">The update item.</param>
        internal static void BroadcastUpdate(Update updateItem) 
        {
            // Fetch the hub's context to broadcast
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<LiveUpdate.Hubs.LiveUpdateHub>();

            // Call the hub's feedUpdated method with our news / event item.
            context.Clients.feedUpdated(updateItem);
        }        
    }
}
