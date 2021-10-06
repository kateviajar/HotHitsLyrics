using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotHitsLyrics.Data;
using HotHitsLyrics.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HotHitsLyrics.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment; 

        //Use IWebHostEnvironment to get the wwwroot path
        public AlbumsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            //Add OrderBy to sort the Album list by Name
            var applicationDbContext = _context.Albums.Include(a => a.Artist).OrderBy(a => a.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            // Add OrderBy() to sort the Artists Name order in the dropdown list
            ViewData["ArtistId"] = new SelectList(_context.Artists.OrderBy(a => a.Name), "ArtistId", "Name");
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind PhotoFile instead of Photo
        public async Task<IActionResult> Create([Bind("AlbumId,Name,ReleasedYear,PhotoFile,ArtistId")] Album album)
        {
            if (ModelState.IsValid)
            {
                //Save upload photo file to the /wwwroot/Image
                //get the wwwroot path
                string wwwRootPath = _hostEnvironment.WebRootPath;
                //store album name as fileName
                string fileName = album.Name;
                //get the extension of the file
                string extension = Path.GetExtension(album.PhotoFile.FileName);
                //Generate an unique file name and store in Photo column
                album.Photo = fileName + album.ArtistId + extension;

                //The path of photo file
                string path = Path.Combine(wwwRootPath + "/Image", album.Photo);

                //To save the photo file in /wwwroot/Image
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await album.PhotoFile.CopyToAsync(fileStream);
                }

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);

            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            //Add OrderBy() to sort the Artists Name order in the dropdown list
            ViewData["ArtistId"] = new SelectList(_context.Artists.OrderBy(a => a.Name), "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Bind PhotoFile instead of Photo
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,Name,ReleasedYear,Photo,PhotoFile,ArtistId")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                //Save upload photo file to the /wwwroot/Imag
                //get the wwwroot path
                string wwwRootPath = _hostEnvironment.WebRootPath;
                //store album name as fileName
                string fileName = album.Name;
                //get the extension of the file
                string extension = Path.GetExtension(album.PhotoFile.FileName);
                //Generate an unique file name and store in Photo column
                album.Photo = fileName + album.ArtistId + extension;

                //The path of photo file
                string path = Path.Combine(wwwRootPath + "/Image", album.Photo);

                //To save the photo file in /wwwroot/Image, if the path is the same, overwrite the file
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await album.PhotoFile.CopyToAsync(fileStream);
                }

                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await _context.Albums.FindAsync(id);

            //delete file from wwwroot/Image folder
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Image", album.Photo);

            //check whether the file exists
            if(System.IO.File.Exists(imagePath))
            {
                //if yes, delete the file
                System.IO.File.Delete(imagePath);
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
