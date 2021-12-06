using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC5.Models;
using TestMVC5.Services;

namespace TestMVC5.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomersServices  _services = new CustomersServices();

        MvcDatasetEntities db = new MvcDatasetEntities();
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Liste()
        {
            //Je demande au controleur de récupérer la liste des Customers du Model apres la View affiche ce quelle veut et de ca facon 
            //var customers = db.Customers.ToList();
            //return View(customers);

            // Or using services
            //if (ModelState.IsValid)
            //{
            //    _services.ToListing();
            //}


            //    return View();
            return View(db.Customers.ToList());
            //return View();
        }

        // la vue ou il ya le formulaire d'ajout
        public ActionResult AddCustomer()
        {
            return View();
        }

        ///dedans il ya la vue qui gére le formulaire
        // cette vue va nous permettre d'ajouter un client

        //COMPARER LES DEUX M2THODES / AVEC PARAMETRES / SANS PARAMETRES

        //[HttpPost]
        //public ActionResult SaveNewCustomer(int id, string nom, string prenom, int age, decimal facture, string message)
        //{
        //    var client = new Customers()
        //    {
        //        FirstName = nom,
        //        LastName = prenom,
        //        Age = age,
        //        Invoice = facture,
        //        CustomerOpinion = message
        //    };

        //    db.Customers.Add(client);
        //    db.SaveChanges();
        //    // RedirectToAction("Liste") et non pas View("Liste")!!!!!!!!!!
        //    return RedirectToAction("Liste");
        //}


        [HttpPost]
        public ActionResult SaveNewCustomer(Customers client)
        {

            if (ModelState.IsValid)
            {

                _services.AddNewCustomer(client);
                // si le model est valid( dont les conditions REQUIRED Sont respectés ) on retourne vers notre Liste ...
                return RedirectToAction("Liste");

            }
            // sinon onreste sur la vue pour afficher les erreurs (les coriger)
            return View("AddCustomer");

        }

        // Test 
        //[HttpPost]
        //public ActionResult AddCustomer(Customers client)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _services.AddNewCustomer(client);

        //    }

        //    return View();
        //}

        //Ce message d’erreur est créé automatiquement par le framework de validation à partir de ce que nous avons dans le modèle 
        //////////Ici on voulait utiliser la méthode  (ViewBag.MessageErreur) mais ca ne fonctionne pas !!!!!!!!!//////////////////////////
        //if (string.IsNullOrWhiteSpace(client.LastName))
        //{
        //    ViewBag.MessageErreur("Vous devez remplir ce champ");

        //}
        // AddNewCustomer est une méthode qui se trouve dans le dossier Sevices

        public ActionResult DeleteCustomer(int id)
        {

            _services.ToDeleteCustomer(id);

            return RedirectToAction("Liste");
        }


        // Détails du client

        public ActionResult DetailsCustomer(int Id)
        {
              ////////////////////////////////////////////////////////////////////////////////////////////////////////
             /////////// Stocker le résultat de la requéte services afin de l'envoyer à la vue////////////////////////
             /////////////////////////////////////////////////////////////////////////////////////////////////////////
           var client =  _services.DisplayCustomerDetails(Id);

            return View(client);

        }


        public ActionResult DropDown()
        {
            var liste = _services.ToListing();

            return View(liste);
        }
    }
}