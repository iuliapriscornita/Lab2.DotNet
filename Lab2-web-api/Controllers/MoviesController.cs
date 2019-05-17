﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab2_web_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2_web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private MoviesDbContext context;
        public MoviesController(MoviesDbContext context)
        {
            this.context = context;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return context.Movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var existing = context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return NotFound();
            }

            return Ok(existing);
        }

        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody] Movie movie)
        {
            //if (!ModelState.IsValid)
            //{

            //}
            context.Movies.Add(movie);
            context.SaveChanges();
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var existing = context.Movies.AsNoTracking().FirstOrDefault(f => f.Id == id);
            if (existing == null)
            {
                context.Movies.Add(movie);
                context.SaveChanges();
                return Ok(movie);
            }
            movie.Id = id;
            context.Movies.Update(movie);
            context.SaveChanges();
            return Ok(movie);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = context.Movies.FirstOrDefault(movie => movie.Id == id);
            if (existing == null)
            {
                return NotFound();
            }
            context.Movies.Remove(existing);
            context.SaveChanges();
            return Ok();
        }
    }
}