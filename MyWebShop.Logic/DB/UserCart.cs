using System;
using System.Collections.Generic;

namespace MyWebShop.Logic.DB
{
    public partial class UserCart
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ItemId { get; set; }

        public Items Item { get; set; }
        public Users User { get; set; }
    }
}
