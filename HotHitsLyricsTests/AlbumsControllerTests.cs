using HotHitsLyrics.Controllers;
using HotHitsLyrics.Data;
using HotHitsLyrics.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotHitsLyricsTests
{
    [TestClass]
    public class AlbumsControllerTests
    {
        // class level variables for all tests
        private ApplicationDbContext _context;
        private IWebHostEnvironment _hostEnvironment;
        AlbumsController controller;

        //this variable stores a list of Album
        List<Album> albums = new List<Album>();

        //Add a TestInitialize()
        [TestInitialize]
        public void TestInitialize()
        {
            // create an in-memory db
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // populate mock data
            var artist = new Artist
            {
                ArtistId = 777,
                Name = "The Best Artist"
            };

            _context.Artists.Add(artist); // add the artist to Artists db set

            albums.Add(new Album
            { 
                AlbumId = 101,
                Name = "Rock the World",
                ReleasedYear = 2021,
                ArtistId = 777,
                Artist = artist
            });

            albums.Add(new Album
            {
                AlbumId = 369,
                Name = "Listen to Me",
                ReleasedYear = 2015,
                ArtistId = 777,
                Artist = artist
            });

            albums.Add(new Album
            {
                AlbumId = 265,
                Name = "My Song",
                ReleasedYear = 2019,
                ArtistId = 777,
                Artist = artist
            });

            // add all albums to Albums db set
            foreach(var album in albums)
            {
                _context.Albums.Add(album);
            }
            _context.SaveChanges(); //commit the change

            //instantiate an AlbumsController
            controller = new AlbumsController(_context, _hostEnvironment);
        }

        #region CreatePOST

        [TestMethod]
        public void CreateInvalidModelLoadsCreateView()
        {
            //arrang
            Album album = new Album
            {
                AlbumId = 123,
                Name = "Test",
                ReleasedYear = 2022,
                ArtistId = 666
            };

            controller.ModelState.AddModelError("Name", "Error");

            //act
            var result = (ViewResult)controller.Create(album).Result;

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateInvalidModelLoadsAlbum()
        {
            //arrang
            Album album = new Album
            {
                AlbumId = 123,
                Name = "Test",
                ReleasedYear = 2022,
                ArtistId = 666
            };

            controller.ModelState.AddModelError("Name", "Error");

            //act
            var result = (ViewResult)controller.Create(album).Result;

            //assert
            Assert.AreEqual(album, result.Model);
        }

        [TestMethod]
        public void CreateInvalidModelViewDataNotNull()
        {
            //arrang
            Album album = new Album
            {
                AlbumId = 123,
                Name = "Test",
                ReleasedYear = 2022,
                ArtistId = 666
            };

            controller.ModelState.AddModelError("Name", "Error");

            //act
            var result = (ViewResult)controller.Create(album).Result;

            //assert
            Assert.IsNotNull(result.ViewData["ArtistId"]);
        }

        [TestMethod]
        public void CreateValidModelRedirectIndex()
        {
            //arrang
            Album album = new Album
            {
                AlbumId = 123,
                Name = "Test",
                ReleasedYear = 2022,
                ArtistId = 666
            };

            //act
            var result = (RedirectToActionResult)controller.Create(album).Result;

            //assert
            Assert.AreEqual("Index", result.ActionName);
        }

        [TestMethod]
        public void CreateValidModelInsertAlbum()
        {
            //arrang
            Album album = new Album
            {
                AlbumId = 123,
                Name = "Test",
                ReleasedYear = 2022,
                ArtistId = 666
            };

            //act
            var result = (RedirectToActionResult)controller.Create(album).Result;

            //assert
            Assert.AreEqual(album, _context.Albums.Find(album.AlbumId));
        }

        #endregion

        #region Index

        [TestMethod]
        public void IndexLoadsIndexView()
        {
            //arrange - in-memory db
            //act
            var result = (ViewResult)controller.Index(null).Result;

            //assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexLoadsAlbums()
        {
            //arrange - in-memory db
            //act
            var result = (ViewResult)controller.Index(null).Result;
            List<Album> model = (List<Album>)result.Model;

            //assert - a list of albumns is expected to sort by name
            CollectionAssert.AreEqual(albums.OrderBy(a => a.Name).ToList(), model);
        }

        [TestMethod]
        public void IndexLoadsSearchedAlbums()
        {
            //arrange - in-memory db
            String albumName = "Rock";
            //act
            var result = (ViewResult)controller.Index(albumName).Result;
            List<Album> model = (List<Album>)result.Model;

            //assert - a list of albumns is expected to sort by name
            CollectionAssert.AreEqual(albums.Where(a => a.Name.Contains(albumName)).OrderBy(a => a.Name).ToList(), model);
        }

        #endregion
    }
}
