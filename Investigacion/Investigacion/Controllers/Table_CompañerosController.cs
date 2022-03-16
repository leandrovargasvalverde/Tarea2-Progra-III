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
using Investigacion.Models;

namespace Investigacion.Controllers
{
    public class Table_CompañerosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Table_Compañeros
        public IQueryable<Table_Compañeros> GetTable_Compañeros()
        {
            return db.Table_Compañeros;
        }

        // GET: api/Table_Compañeros/5
        [ResponseType(typeof(Table_Compañeros))]
        public IHttpActionResult GetTable_Compañeros(int id)
        {
            Table_Compañeros table_Compañeros = db.Table_Compañeros.Find(id);
            if (table_Compañeros == null)
            {
                return NotFound();
            }

            return Ok(table_Compañeros);
        }

        // PUT: api/Table_Compañeros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTable_Compañeros(int id, Table_Compañeros table_Compañeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != table_Compañeros.ID)
            {
                return BadRequest();
            }

            db.Entry(table_Compañeros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Table_CompañerosExists(id))
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

        // POST: api/Table_Compañeros
        [ResponseType(typeof(Table_Compañeros))]
        public IHttpActionResult PostTable_Compañeros(Table_Compañeros table_Compañeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Table_Compañeros.Add(table_Compañeros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = table_Compañeros.ID }, table_Compañeros);
        }

        // DELETE: api/Table_Compañeros/5
        [ResponseType(typeof(Table_Compañeros))]
        public IHttpActionResult DeleteTable_Compañeros(int id)
        {
            Table_Compañeros table_Compañeros = db.Table_Compañeros.Find(id);
            if (table_Compañeros == null)
            {
                return NotFound();
            }

            db.Table_Compañeros.Remove(table_Compañeros);
            db.SaveChanges();

            return Ok(table_Compañeros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Table_CompañerosExists(int id)
        {
            return db.Table_Compañeros.Count(e => e.ID == id) > 0;
        }
    }
}