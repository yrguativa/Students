using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Students.API.Models;

namespace Students.API.Controllers
{
    public class CursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Curses
        public IQueryable<Curse> GetCurses()
        {
            return db.Curses;
        }

        // GET: api/Curses/5
        [ResponseType(typeof(Curse))]
        public async Task<IHttpActionResult> GetCurse(int id)
        {
            Curse curse = await db.Curses.FindAsync(id);
            if (curse == null)
            {
                return NotFound();
            }

            return Ok(curse);
        }

        // PUT: api/Curses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurse(int id, Curse curse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curse.Id)
            {
                return BadRequest();
            }

            db.Entry(curse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurseExists(id))
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

        // POST: api/Curses
        [ResponseType(typeof(Curse))]
        public async Task<IHttpActionResult> PostCurse(Curse curse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Curses.Add(curse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = curse.Id }, curse);
        }

        // DELETE: api/Curses/5
        [ResponseType(typeof(Curse))]
        public async Task<IHttpActionResult> DeleteCurse(int id)
        {
            Curse curse = await db.Curses.FindAsync(id);
            if (curse == null)
            {
                return NotFound();
            }

            db.Curses.Remove(curse);
            await db.SaveChangesAsync();

            return Ok(curse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurseExists(int id)
        {
            return db.Curses.Count(e => e.Id == id) > 0;
        }
    }
}