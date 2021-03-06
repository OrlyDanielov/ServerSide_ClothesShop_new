﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Web;

namespace ClassLibrary
{
    public class DBQuery
    {
        public static bool AddNewClothe(Clothe newClothe)
        {
            try
            {
                ClothesShopDBConnection db = new ClothesShopDBConnection();
                db.Entry(newClothe).State = System.Data.Entity.EntityState.Added; //  add the new clothe to the db
                db.SaveChanges();
                return true;
            }
            catch (Exception)//(Exception e)
            {
                return false;
            }
        }

        public static bool UpdateProductInv_AND_addedPurchase(List<Purchase> p_purchases)
        {
            try
            {
                ClothesShopDBConnection db = new ClothesShopDBConnection(); // update the amount in stock for evey clothe that purchased

                foreach (var p in p_purchases)
                {
                    //p.amount = p.amount ?? 0;
                    var cl = db.Clothes.SingleOrDefault(x => x.number == p.clothe_number);
                    if (cl != null) // update the clothes amount in stock in the db
                    {
                        cl.amount_in_stock -= p.amount;
                    }
                    else
                    {
                        return false;
                    }
                    //added the new purcheses to the db
                    //db.Entry(p).State = System.Data.Entity.EntityState.Added;
                    db.Purchases.Add(p);
                }
                //Save Transaction
                db.SaveChanges();
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine("");
                Debug.WriteLine(E.InnerException);
                Debug.WriteLine("555555555");
                Debug.WriteLine(E.ToString());
                
                return false;
            }
        }
    }
}
