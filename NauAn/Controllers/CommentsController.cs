using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NauAn.Models;
using NauAn.Models.Entities;

namespace NauAn.Controllers
{
    public class CommentsController : Controller
    {
        private readonly DBNAContext _context;

        public CommentsController(DBNAContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var dBNAContext = _context.Comments.Include(c => c.CommentOfUser).Include(c => c.Post);
            return View(await dBNAContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.CommentOfUser)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "UserName");
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "Content");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Content,UserID,PostID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                string postID = comment.PostID.ToString();
                string url = "/Posts/Details/" + postID;
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectPermanent(url);

            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Password", comment.UserID);
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "Content", comment.PostID);
            
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Password", comment.UserID);
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "Content", comment.PostID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Content,UserID,PostID")] Comment comment)
        {
            if (id != comment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                string postID = comment.PostID.ToString();
                string urlPost = "/Posts/Details/" + postID;
                return RedirectPermanent(urlPost);
            }
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Password", comment.UserID);
            ViewData["PostID"] = new SelectList(_context.Posts, "ID", "Content", comment.PostID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.CommentOfUser)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            string postID = comment.PostID.ToString();
            string urlPost = "/Posts/Details/" + postID;
            return RedirectPermanent(urlPost);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.ID == id);
        }

        //public JsonResult List()
        //{
        //     ;
        //}
        [HttpPost]
        public IActionResult AddCMT(Comment cmt)
        {
            return Json(cmt) ;
        }

        //public JsonResult Update()
        //{
        // ;
        //}

    }
}
