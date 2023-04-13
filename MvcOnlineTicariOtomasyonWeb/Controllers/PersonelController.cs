using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyonWeb.Models.Siniflar;

namespace MvcOnlineTicariOtomasyonWeb.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c=new Context();
        public ActionResult Index()
        {
            var degerler=c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmanlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,//dropdownlistte kullanıcıya gozukecek kısım için text kullandım.
                                               Value = x.Departmanid.ToString()//dropdownlisste arka planda id ile işlem yapabilmek için value kullandım.
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmanlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,//dropdownlistte kullanıcıya gozukecek kısım için text kullandım.
                                               Value = x.Departmanid.ToString()//dropdownlisste arka planda id ile işlem yapabilmek için value kullandım.
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var prs=c.Personels.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn=c.Personels.Find(p.Personelid);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PeresonelSoyad = p.PeresonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
    }
}