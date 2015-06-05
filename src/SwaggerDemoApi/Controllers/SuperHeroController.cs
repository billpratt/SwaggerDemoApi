using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using SwaggerDemoApi.Models;

namespace SwaggerDemoApi.Controllers
{
    /// <summary>
    /// Superhero api
    /// </summary>
    public class SuperHeroController : ApiController
    {
        private static readonly List<Superhero> Superheroes = new List<Superhero>
            {
                new Superhero
                {
                    Id = Guid.NewGuid(),
                    Name = "Batman",
                    RealName = "Bruce Wayne",
                    Universe = Universe.Dc
                },
                new Superhero
                {
                    Id = Guid.NewGuid(),
                    Name = "Wolverine",
                    RealName = "Logan",
                    Universe = Universe.Marvel
                }
            };

        /// <summary>
        /// Get all superheroes
        /// </summary>
        /// <remarks>
        /// Get a list of all superheroes
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<Superhero>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Superheroes);
        }

        /// <summary>
        /// Get superhero by id
        /// </summary>
        /// <remarks>
        /// Get a superhero by id
        /// </remarks>
        /// <param name="id">Id of superhero</param>
        /// <returns></returns>
        /// <response code="200">Superhero found</response>
        /// <response code="404">Superhero not foundd</response>
        [ResponseType(typeof(Superhero))]
        public HttpResponseMessage Get(Guid id)
        {
            var superhero = Superheroes.FirstOrDefault(c => c.Id == id);

            return superhero == null
                ? Request.CreateErrorResponse(HttpStatusCode.NotFound, "Superhero not found")
                : Request.CreateResponse(HttpStatusCode.OK, superhero);
        }

        /// <summary>
        /// Add new superhero
        /// </summary>
        /// <remarks>
        /// Add a new superhero
        /// </remarks>
        /// <param name="postSuperheroModel">Superhero to add</param>
        /// <returns></returns>
        /// <response code="201">Superhero created</response>
        [ResponseType(typeof(Superhero))]
        public HttpResponseMessage Post(PostSuperheroModel postSuperheroModel)
        {
            // Map a PostSuperheroModel object to Superhero object
            var superhero = Mapper.Map<Superhero>(postSuperheroModel);

            superhero.Id = Guid.NewGuid();
            Superheroes.Add(superhero);

            return Request.CreateResponse(HttpStatusCode.Created, superhero);
        }

        /// <summary>
        /// Update an existing superhero
        /// </summary>
        /// <param name="putSuperheroModel">Superhero to update</param>
        /// <returns></returns>
        /// <response code="200">Superhero updated</response>
        /// <response code="404">Superhero not found</response>
        [ResponseType(typeof(Superhero))]
        public HttpResponseMessage Put(PutSuperheroModel putSuperheroModel)
        {
            var existingSuperhero = Superheroes.FirstOrDefault(c => c.Id == putSuperheroModel.Id);
            if (existingSuperhero == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Superhero not found");

            var superhero = Mapper.Map<Superhero>(putSuperheroModel);
            Superheroes.Remove(existingSuperhero);
            Superheroes.Add(superhero);

            return Request.CreateResponse(HttpStatusCode.OK, superhero);
        }

        /// <summary>
        /// Delete a superhero
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(Guid id)
        {
            var existingSuperhero = Superheroes.FirstOrDefault(c => c.Id == id);

            if (existingSuperhero == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Superhero not found");

            Superheroes.Remove(existingSuperhero);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
