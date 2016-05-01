using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class CharactersController : Controller
    {
        private EFDBContext db = new EFDBContext();

        // GET: Characters
        public async Task<ActionResult> Index()
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");

            return View(await db.Characters.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id,PicturePath,Name,Description,Cost,LifeStatus,Sex")] Character character)
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                if (Request.Files[0].FileName != "")
                {
                    character.PicturePath = Request.Files[0].FileName;
                    Request.Files[0].SaveAs(Server.MapPath("~") + "/Content/Images/" + character.PicturePath);
                }
                else
                    character.PicturePath = Server.MapPath("~") + "/Content/Images/peppa.jpg";

                db.Characters.Add(character);
                await db.SaveChangesAsync();
                return RedirectToAction("List", "Character");
            }

            return RedirectToAction("List", "Character");
        }

        // GET: Characters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = await db.Characters.FindAsync(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View("Edit",character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PicturePath,Name,Description,Cost,LifeStatus,Sex")] Character character)
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("List", "Character");
            }
            return RedirectToAction("List", "Character");
        }


        // POST: Characters/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("Login", "Account");

            Character character = await db.Characters.FindAsync(id);
            db.Characters.Remove(character);
            await db.SaveChangesAsync();
            return RedirectToAction("List", "Character");
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
