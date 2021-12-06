using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVC5.Models;

namespace TestMVC5.Services
{
    public class CustomersServices
    {

        public List<Customers> ToListing()
        {
            var liste = new List<Customers>();
            using (MvcDatasetEntities db = new MvcDatasetEntities())
            {
                liste = db.Customers.ToList();
            }

            return liste;
        }


        public void AddNewCustomer(Customers client )
        {
            using (MvcDatasetEntities db = new MvcDatasetEntities())
            {
                db.Customers.Add(client);
                db.SaveChanges();
            }

        }

        // The ajax methode https://stackoverflow.com/questions/4682107/delete-actionlink-with-confirm-dialog

        public void ToDeleteCustomer(int id)
        {
            using (MvcDatasetEntities db = new MvcDatasetEntities())
            {
                var customer = db.Customers.Find(id);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }


        }

        // Détails 

        public Customers DisplayCustomerDetails(int Id)
        {
            var client = new Customers();

            using (MvcDatasetEntities db = new MvcDatasetEntities())
            {
                client = db.Customers.Find( Id);

            }

            return client;
        }
        


    }
}