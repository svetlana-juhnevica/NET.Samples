using MyWebShop.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWebShop.Logic
{
    public class UserCartManager
    {
        public static void Create(int userId, int itemId)
        {
            //realizeta saglabasana DB tabula UserCart
            using (var db = new DbContext())
            {
                db.UserCart.Add(new UserCart()
                {
                    UserId = userId,
                    ItemId = itemId,
                });
                db.SaveChanges();
            }

        }
        public static List<UserCart> GetByUser(int userId)
        {
            using (var db = new DbContext())
            {
                // realizeta lietotaja groza datu atlase  no DB tabulas UserCart
                // var userCart = db.UserCart.Where(c => c.UserId == userId).ToList();
                //katram groza ierakstam atlasa atbilstosa "item" datus
                //todo; izmantot SQL join
                //foreach (var item in userCart)
                // {
                //     item.Item = db.Items.Find(item.ItemId);
                // }
                var userCart = db.UserCart.Where(c => c.UserId == userId).Join(db.Items, c => c.ItemId, i => i.Id, (c, i) => new UserCart()
                {
                    Item = i
                }).ToList();
                //select * from UserCart where UserId = @userId
                //select * from Items where Id = @itemId1
                //select * from Items where Id = @itemId2
                //select * from Items where Id = @itemId3

                //SQL JOIN
                //select *from UserCart c, Items i where c.UserId = @userId AND i.Id =c. ItemId

                return userCart;
            }
        }
        public static void DeleteFromCart(int id)
        {
            using (var db = new DbContext())
            {
                db.UserCart.Remove(db.UserCart.FirstOrDefault(i => i.ItemId == id));
                db.SaveChanges();
            }
        }
        public static void DeleteAll()
        {
            using (var db = new DbContext())
            {
                db.UserCart.RemoveRange(db.UserCart);
                db.SaveChanges();
            }
        }
        public static int GetItemCount(int id)
        {
            using (var db = new DbContext())
            {
                return db.UserCart.Count(i => i.ItemId == id);
            }
        }
    }
}