using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiveUpdate.Models
{
    /// <summary>
    /// Basic utility properties and methods to facilitate the demo
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Determines the type of update for the sake of icons.
        /// </summary>
        public enum UpdateType
        { 
            News,
            Event
        }

        /// <summary>
        /// Generates the update list with static content. This would be replaced with content from an updates datatabase table.
        /// </summary>
        /// <returns>List of updates</returns>
        internal static List<Update> GenerateUpdateList()
        {
            return new List<Update>
            {  
                new Update 
                {
                    ID = 1, 
                    Name = "News story 1", 
                    PublishDate = DateTime.Parse("12/07/2012"),
                    UpdateType = UpdateType.News.ToString()
                },
                new Update
                {
                    ID = 2,
                    Name = "News story 2",
                    PublishDate = DateTime.Parse("11/07/2012"),
                    UpdateType = UpdateType.News.ToString()
                },
                new Update
                {
                    ID = 3,
                    Name = "Event 1",
                    PublishDate = DateTime.Parse("10/07/2012"),
                    UpdateType = UpdateType.Event.ToString()
                },
                new Update
                {
                    ID = 4,
                    Name = "News story 3",
                    PublishDate = DateTime.Parse("09/07/2012"),
                    UpdateType = UpdateType.News.ToString()
                },
                new Update
                {
                    ID = 5,
                    Name = "Event 2",
                    PublishDate = DateTime.Parse("08/07/2012"),
                    UpdateType = UpdateType.Event.ToString()
                }
            }.OrderByDescending(m=>m.PublishDate).ToList();
        }
    }
}