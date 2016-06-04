using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ASPNETProjekatAutootpad.Models;

namespace ASPNETProjekatAutootpad.Controllers
{
    public class _DioServiceController : ApiController
    {
        private ASPNETProjekatAutootpadContext db = new ASPNETProjekatAutootpadContext();

        // GET: api/_DioService
        public IQueryable<_Dio> Get_Dio()
        {
            return db._Dio;
        }

        // GET: api/_DioService/5
        [ResponseType(typeof(_Dio))]
        public IHttpActionResult Get_Dio(int id)
        {
            _Dio _Dio = db._Dio.Find(id);
            if (_Dio == null)
            {
                return NotFound();
            }

            return Ok(_Dio);
        }

        // PUT: api/_DioService/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put_Dio(int id, _Dio _Dio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != _Dio.ID)
            {
                return BadRequest();
            }

            db.Entry(_Dio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_DioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/_DioService
        [ResponseType(typeof(_Dio))]
        public IHttpActionResult Post_Dio(_Dio _Dio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db._Dio.Add(_Dio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = _Dio.ID }, _Dio);
        }

        // DELETE: api/_DioService/5
        [ResponseType(typeof(_Dio))]
        public IHttpActionResult Delete_Dio(int id)
        {
            _Dio _Dio = db._Dio.Find(id);
            if (_Dio == null)
            {
                return NotFound();
            }

            db._Dio.Remove(_Dio);
            db.SaveChanges();

            return Ok(_Dio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool _DioExists(int id)
        {
            return db._Dio.Count(e => e.ID == id) > 0;
        }
    }
}