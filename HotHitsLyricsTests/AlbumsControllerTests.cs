using HotHitsLyrics.Controllers;
using HotHitsLyrics.Data;
using HotHitsLyrics.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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



        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
