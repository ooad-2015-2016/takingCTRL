using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPNETProjekatAutootpad.Models;

namespace ASPNETProjekatAutootpad.Controllers
{
    public class _DioController : Controller
    {
        private ASPNETProjekatAutootpadContext db = new ASPNETProjekatAutootpadContext();

        public ActionResult dajSliku(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Dio _Dio = db._Dio.Find(id);
            if(_Dio.Slika == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            byte[] imageByteData = _Dio.Slika;
            return File(imageByteData, "image/png");
        }
        // GET: _Dio
        public ActionResult Index()
        {
            return View(db._Dio.ToList());
        }

        // GET: _Dio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Dio _Dio = db._Dio.Find(id);
            if (_Dio.QR != null)
            {
                byte[] imageByteData = _Dio.QR;
                string imageBase64Data = Convert.ToBase64String(imageByteData);
                string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
                ViewBag.ImageData = imageDataURL;
            }
            if (_Dio == null)
            {
                return HttpNotFound();
            }
            return View(_Dio);
        }

        // GET: _Dio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: _Dio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProdajnaCijena,Model,Proizvodjac,ImeDijela,UProdaji,QR,Slika")] _Dio _Dio)
        {
            if (ModelState.IsValid)
            {
                db._Dio.Add(_Dio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_Dio);
        }

        // GET: _Dio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Dio _Dio = db._Dio.Find(id);
            if (_Dio == null)
            {
                return HttpNotFound();
            }
            return View(_Dio);
        }

        // POST: _Dio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProdajnaCijena,Model,Proizvodjac,ImeDijela,UProdaji,QR,Slika")] _Dio _Dio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(_Dio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_Dio);
        }

        // GET: _Dio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _Dio _Dio = db._Dio.Find(id);
            if (_Dio == null)
            {
                return HttpNotFound();
            }
            return View(_Dio);
        }

        // POST: _Dio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _Dio _Dio = db._Dio.Find(id);
            db._Dio.Remove(_Dio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
