using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jewelly.Models
{
    public class CartModel
    {
        public int UserID { get; set; }
        public int Id { get; set; }
        public string product { get; set; }
        public decimal MRP { get; set; }
        public string Email { get; set; }
        public string date { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }

        public string orderdate { get; set; }
        public string shipcity { get; set; }
        public string ordercode { get; set; }
        public string shipcode { get; set; }
        public string shipcountry { get; set; }
        public string adminname { get; set; }
        public string userFname { get; set; }
        public string userLname { get; set; }

        public string payment { get; set; }
    }
    public class Joinc
    {
        JwelleyEntities db = new JwelleyEntities();
        public List<CartModel> GetCart(string search="")
        {
            var car = (from c in db.CartLists
                       join u in db.UserRegMsts on c.userID equals u.userID
                       join a in db.AdminLoginMsts on c.userName equals a.userName
                       join p in db.Payments on c.payment_ID equals p.ID

                       where c.userID == u.userID && c.userName == a.userName && c.Product_Name == search
                       select new CartModel
                       {
                           UserID = u.userID,
                           Id = c.ID,
                           product = c.Product_Name,
                           MRP = c.MRP,
                           Email = c.Email_ID,
                           date = c.OrderDate,
                           shipname = c.ShipName,
                           shipaddress = c.ShipAddress,
                           orderdate = c.OrderDate,
                           ordercode = c.OrderCode,
                           shipcity = c.ShipCity,
                           shipcountry = c.ShipCountry,
                           shipcode = c.ShipCode,
                           adminname = a.userName,
                           userFname = u.userFname,
                           userLname = u.userLname,
                           payment = p.type
                       }).ToList();
            return car;
        }
    }
}