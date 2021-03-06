﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_web_api.Models
{
    public class MoviesDbSeeder
    {
        public static void Initialize(MoviesDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Movies.Any())
            {
                return;   // DB has been seeded
            }

            context.Movies.AddRange(
                new Movie
                {
                    Title = "Movie1",
                    Description = "First ",
                    Genre = "Horror",
                    Duration = 40,
                    YearOfRelease = 2000,
                    Director = "Ion",
                    Rating = 4,
                    Watched = "yes",
                },
                new Movie
                {

                    Title = "Movie2",
                    Description = "Second",
                    Genre = "Action",
                    Duration = 60,
                    YearOfRelease = 2001,
                    Director = "Ion",
                    Rating = 4,
                    Watched = "no",
                            }
            );
            context.SaveChanges(); // commit transaction


        }
    }
}
