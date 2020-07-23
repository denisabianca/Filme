using AutoMapper;
using FilmeWebApi.Entities;
using FilmeWebApi.ExternalModels;
using FilmeWebApi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FilmeWebApi.Controllers
{
    [Route("movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieUnitOfWork _movieUnit;
        private readonly IMapper _mapper;

        public MovieController(IMovieUnitOfWork movieUnit,
            IMapper mapper)
        {
            _movieUnit = movieUnit ?? throw new ArgumentNullException(nameof(movieUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        #region Movies
        [HttpGet]
        [Route("{id}", Name = "GetMovie")]
        public IActionResult GetMovie(Guid id)
        {
            var movieEntity = _movieUnit.Movies.Get(id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovieDTO>(movieEntity));
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetMovieDetails")]
        public IActionResult GetMovieDetails(Guid id)
        {
            var movieEntity = _movieUnit.Movies.GetMovieDetails(id);
            if (movieEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovieDTO>(movieEntity));
        }

        [Route("add", Name = "Add a new movie")]
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieDTO movie)
        {
            var movieEntity = _mapper.Map<Movie>(movie);
            _movieUnit.Movies.Add(movieEntity);

            _movieUnit.Complete();

            _movieUnit.Movies.Get(movieEntity.Id);

            return CreatedAtRoute("GetMovie",
                new { id = movieEntity.Id },
                _mapper.Map<MovieDTO>(movieEntity));
        }
        #endregion Movies

        #region Directors
        [HttpGet]
        [Route("director/{directorId}", Name = "GetDirector")]
        public IActionResult GetDirector(Guid directorId)
        {
            var directorEntity = _movieUnit.Directors.Get(directorId);
            if (directorEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DirectorDTO>(directorEntity));
        }

        [HttpGet]
        [Route("director", Name = "GetAllDirectors")]
        public IActionResult GetAllDirectors()
        {
            var directorEntities = _movieUnit.Directors.Find(a => a.Deleted == false || a.Deleted == null);
            if (directorEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<DirectorDTO>>(directorEntities));
        }

        [Route("director/add", Name = "Add a new director")]
        [HttpPost]
        public IActionResult AddDirector([FromBody] DirectorDTO director)
        {
            var directorEntity = _mapper.Map<Director>(director);
            _movieUnit.Directors.Add(directorEntity);

            _movieUnit.Complete();

            _movieUnit.Directors.Get(directorEntity.Id);

            return CreatedAtRoute("GetDirector",
                new { directorId = directorEntity.Id },
                _mapper.Map<DirectorDTO>(directorEntity));
        }

        [Route("director/{directorId}", Name = "Mark director as deleted")]
        [HttpPut]
        public IActionResult MarkDirectorAsDeleted(Guid directorId)
        {
            var director = _movieUnit.Directors.FindDefault(a => a.Id.Equals(directorId) && (a.Deleted == false || a.Deleted == null));
            if (director != null)
            {
                director.Deleted = true;
                if (_movieUnit.Complete() > 0)
                {
                    return Ok("Director " + directorId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Directors
    }
}