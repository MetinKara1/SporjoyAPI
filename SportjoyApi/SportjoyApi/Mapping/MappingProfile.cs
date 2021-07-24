using Api.DTO;
using AutoMapper;
using Core.Models;
using Sporjoy.Api.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sporjoy.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            //CreateMap<Product, ProductDTO>();

            // Resource to Domain
            //CreateMap<ProductDTO, Product>();

            //CreateMap<SaveMusicDTO, Music>();
            //CreateMap<SaveArtistDTO, Artist>();
        }
    }
}
