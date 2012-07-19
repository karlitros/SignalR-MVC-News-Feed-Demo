using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LiveUpdate.Models;
using Newtonsoft.Json.Serialization;

namespace LiveUpdate.Models
{
    public class Update
    {
        public int ID { get; set; }
        public DateTime PublishDate { get; set; }
        public string Name { get; set; }
        public string UpdateType { get; set; }
    }
}