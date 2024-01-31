using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using News_Core6.DI.Post;
using News_Core6.Models;
using News_Core6.Areas.Admin.Data;
using News_Core6.Helpper;

namespace News_Core6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IPostRepository _postRepository;
        public PostsController(AppDbContext context, IPostRepository postRepository)
        {
            _postRepository = postRepository;
            _context = context;
        }

        // GET: Admin/Posts
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Posts.Include(p => p.New);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.New)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Admin/Posts/Create
        public IActionResult Create()
        {
            ViewData["NewId"] = new SelectList(_context.News, "Id", "Title");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Summary,Description,NewId")] Data.Post model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if(file == null)
                {
                    return BadRequest();
                }

                string extension = Path.GetExtension(file.FileName);
                string imageName = Utilities.SEOUrl(file.FileName) + extension;

                var mol_Image = await Utilities.UploadFile(file, @"Product", imageName.ToLower());



              
                model.CreatedDate = DateTime.Now;
                model.DefaultImage = mol_Image;
                model.Data = null;
                model.Alias = Helpper.Utilities.SEOUrl(model.Title);
                var CreateItem = _postRepository.Create(model);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewId"] = new SelectList(_context.News, "Id", "Title", model.NewId);
            return View(model);
        }

        // GET: Admin/Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewData["NewId"] = new SelectList(_context.News, "Id", "Title", post.NewId);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Summary,Description,DefaultImage,Data,Alias,CreatedDate,NewId")] Data.Post post)
        {
            if (id != post.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.Id))
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
            ViewData["NewId"] = new SelectList(_context.News, "Id", "Title", post.NewId);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .Include(p => p.New)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Posts == null)
            {
                return Problem("Entity set 'AppDbContext.Posts'  is null.");
            }
            var post = await _context.Posts.FindAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
          return (_context.Posts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
