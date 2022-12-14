using Makale_BusinessLayer;
using Makale_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Makale_Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //
        NotYonet ny = new NotYonet();
        public ActionResult Index()
        {
            //  Test test1=new Test(); 
            // test1.InsertTest();

            //  test1.UpdateTest();

            //  test1.DeleteTest();

            // test1.YorumEkle();

            

            return View(ny.Listele().OrderByDescending(x=>x.DegistirmeTarihi).ToList());  // indexin artık bir modeli var
        }

        public ActionResult Kategori(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            KategoriYonet ky = new KategoriYonet();
            Kategori kategori = ky.KategoriBul(id.Value);

            if (kategori==null)  // eğer kategoriyi bulamadıysa
            {
                return HttpNotFound();
            }
            return View("Index",kategori.Notlar);

        }

        public ActionResult Begenilenler()
        {
            return View("Index",ny.Listele().OrderByDescending(x=>x.BegeniSayisi).ToList());
        }
       
    }
}