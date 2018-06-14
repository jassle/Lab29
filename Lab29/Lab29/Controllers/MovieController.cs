using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29.Models;

namespace Lab29.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<Info> ShowMovies()
        {
            MovieEntities1 ORM = new MovieEntities1();
            return ORM.Infoes.ToList();

        }
        [HttpGet]
        public List<Info> GetMovieByCategory(string Category)
        {
            MovieEntities1 ORM = new MovieEntities1();
            return ORM.Infoes.Where(c => c.Category.Contains(Category)).ToList();
        }
        [HttpGet]
        public Info RandomMovie()
        {
            MovieEntities1 ORM = new MovieEntities1();
            List<Info> info  = ORM.Infoes.ToList();
            Random r = new Random();
            int result = r.Next(0, info.Count);
            return info[result];
        }
        [HttpGet]
        public Info RandomMovieByCategory(string Category)
        {
            MovieEntities1 ORM = new MovieEntities1();
            List<Info> info = ORM.Infoes.Where(c => c.Category.Contains(Category)).ToList();
            Random r = new Random();
            int result = r.Next(0, info.Count);
            return info[result];
        }
        [HttpGet]
        public List<Info> RandomMoviePicks(int numpicks)
        {
            MovieEntities1 ORM = new MovieEntities1();
            List<Info> info = ORM.Infoes.ToList();
            List<Info> results = new List<Info>();
            Random r = new Random();
            int i;
            for(i = 0; i < numpicks; i++)
            {
                int result = r.Next(0, info.Count);
                results.Add(info[result]);
                info.RemoveAt(result);
            }
            return results;
        }
        [HttpGet]
        public List<String> GetCategories()
        {
            MovieEntities1 ORM = new MovieEntities1();
            return ORM.Infoes.Select(c => c.Category).Distinct().ToList();

        }
        [HttpGet]
        public Info GetInfo(string title)
        {
            MovieEntities1 ORM = new MovieEntities1();
            Info result =ORM.Infoes.Find(title);
            if (result != null)
                return result;
            else
            {
                Info info = new Info { Title = "Movie not Found" };
                return info;
            }
        }
        [HttpGet]
        public List<Info> GetByKeyword(string keyword)
        {
            MovieEntities1 ORM = new MovieEntities1();
            return ORM.Infoes.Where(c => c.Title.Contains(keyword)).ToList();
        }

    }
}
