using HotHitsLyrics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Controllers
{
    public class SongsController : Controller
    {
        // GET: SongsController
        public ActionResult Index()
        {
            //Add namespace HotHitsLyrics.Models and a few rows of data
            List<Songs> songs = new List<Songs>
            {
                new Songs{ SongsId=1, SongName="Happier Than Ever", Genre="Pop", Lyrics="When I'm away from you", ReleasedYear=2021, ArtistsId=1},
                new Songs{SongsId=2, SongName="Afterglow", Genre="Pop", Lyrics="We were love-drunk, waiting on a miracle", ReleasedYear=2020, ArtistsId=2}
            };
            ViewData.Model = songs;

            return View();
        }

        // GET: SongsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SongsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SongsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SongsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SongsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SongsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SongsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
