using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmeWebApi.Profiles
{
    public class MovieProfile: Profile
    {
        public MovieProfile()
        {
            CreateMap<Entities.Director, ExternalModels.DirectorDTO>();
            CreateMap<ExternalModels.DirectorDTO, Entities.Director>();

            CreateMap<Entities.Movie, ExternalModels.MovieDTO>();
            CreateMap<ExternalModels.MovieDTO, Entities.Movie>();
        }
    }
}
