using Application.Models.Responses;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserPageDto>();
            CreateMap<Album, AlbumDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
