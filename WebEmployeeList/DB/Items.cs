using System;
using System.Collections.Generic;

namespace WebEmployeeList.DB
{
    public partial class Items
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string CategoryName { get; set; }
    }
}
