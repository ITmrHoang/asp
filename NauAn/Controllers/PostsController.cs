using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NauAn.Models;
using NauAn.Models.Entities;

namespace NauAn.Controllers
{
    public class PostsController : Controller
    {
        private readonly DBNAContext _context;

        public PostsController(DBNAContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var dBNAContext = _context.Posts.Include(p => p.Category).Include(p => p.User);
            var a = await dBNAContext.ToListAsync();

            return View(await dBNAContext.ToListAsync());
        }
        [HttpGet]
        [Route("PostCategory/{id}")]
        public async Task<IActionResult> PostCategory(int id)
        {
            var dBNAContext = _context.Posts.Where(x => x.CategoryID == id);
            return View(await dBNAContext.ToListAsync());
        }
      
        [HttpGet]
        [Route("HotPost")]
        public async Task<IActionResult> HotPost()
        {
            var dBNAContext = _context.Posts.OrderByDescending(x => x.Rating).Take(5);

            var tt = await dBNAContext.ToListAsync();
            return PartialView("HotPost", tt);
        }
        [HttpGet]
        [Route("SearchPost/{searchString}")]
        public async Task<IActionResult> SearchPost(string searchString)
        {
            //var dBNAContext = _context.Posts.Include(p => p.Category).Include(p => p.User);
            var dBNAContext = _context.Posts.Where(x => x.Title.Contains(searchString));
            //if (!String.IsNullOrEmpty(searchString))
            //{

            //}  
            var tt = await dBNAContext.ToListAsync();
            return View(tt);
        }
        // GET: Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var post = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(m => m.ID == id);
            //var post =  _context.Posts.Find(id);
            //_context.Entry(post).Collection(c => c.Comments).Load();
            //var post = _context.Posts.Where(p => p.ID == id).Include("Comments").ToList();


            if (post == null)
            {
                return NotFound();
            }
            post.Rating = post.Rating + 1;

            _context.Update(post);
            await _context.SaveChangesAsync();

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("UserID") == null)
            {
                return RedirectToAction("Login", "Home");
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "UserName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Image,PostID")] Post item, IFormFile image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (image != null && image.Length > 0)
        //        {
        //            var fileName = Path.GetFileName(image.FileName);
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
        //            using (var fileSteam = new FileStream(filePath, FileMode.Create))
        //            {
        //                await image.CopyToAsync(fileSteam);
        //            }
        //            item.Image = fileName;
        //        }

        //        _context.Add(item);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(item);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PostName,Title,Content,Rating,Image,Video,UserID,CategoryID")] Post post, IFormFile image, IFormFile video)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.Length > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileSteam);
                    }
                    post.Image = fileName;
                }
                if (image != null && image.Length > 0)
                {
                    var fileName2 = Path.GetFileName(video.FileName);
                    var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\video", fileName2);
                    using (var fileSteam2 = new FileStream(filePath2, FileMode.Create))
                    {
                        await video.CopyToAsync(fileSteam2);
                    }
                    post.Video = fileName2;
                }
                post.Rating = 0;
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", post.CategoryID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "UserName", post.UserID);
            return View(post);
        }
        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IFormFile file)
        //{
        //    using (var fileStream =
        //        new FileStream(Path.Combine(_context.Posts., "file.mp4"), FileMode.Create, FileAccess.Write))
        //    {
        //        await file.CopyToAsync(fileStream);
        //    }

        //    return Ok();
        //}
        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            //if (HttpContext.Session.GetString("Role") != "admin" || HttpContext.Session.GetString("UserID") != post.UserID.ToString())
            //{
            //    return RedirectToAction("Index", "Posts");
            //}
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", post.CategoryID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "UserName", post.UserID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PostName,Title,Content,Rating,Image,Video,UserID,CategoryID")] Post post, IFormFile image, IFormFile video)
        {
            if (id != post.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (image != null && image.Length > 0)
                    {
                        var fileName = Path.GetFileName(image.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                        using (var fileSteam = new FileStream(filePath, FileMode.Create))
                        {
                            await image.CopyToAsync(fileSteam);
                        }
                        post.Image = fileName;
                    }
                    if (video != null && video.Length > 0)
                    {
                        var fileName2 = Path.GetFileName(video.FileName);
                        var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\video", fileName2);
                        using (var fileSteam2 = new FileStream(filePath2, FileMode.Create))
                        {
                            await video.CopyToAsync(fileSteam2);
                        }
                        post.Video = fileName2;
                    }
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", post.CategoryID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "UserName", post.UserID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (post == null)
            {
                return NotFound();
            }
            
            //if (HttpContext.Session.GetString("Role") != "admin" || HttpContext.Session.GetString("UserID") != post.UserID.ToString())
            //{
            //    return RedirectToAction("Index", "Posts");
            //}

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.ID == id);
        }
    }
}
