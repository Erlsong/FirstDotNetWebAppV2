using Application.Interfaces;
using AutoMapper;
using Domain.Models;
using Application.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserPageService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper; 

        public UserPageService(IUserRepository userRepository,
                               IAlbumRepository albumRepository,
                               IPostRepository postRepository,
                               ICommentRepository commentRepository,
                               IMapper mapper)
        {
            _userRepository = userRepository;
            _albumRepository = albumRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserPageDetailsAsync(int id)
        {
            
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            
            var albums = await _albumRepository.GetAllByUserAsync(id);
            var posts = await _postRepository.GetAllByUserAsync(id);

            var postIds = posts.Select(p => p.Id).ToList();
            var comments = new List<Comment>();
            if (postIds.Any())
            {
                foreach (var postId in postIds)
                {
                    var postComments = await _commentRepository.GetAllByPostAsync(id);
                    comments.AddRange(postComments);
                }
            }

            var userDto = _mapper.Map<UserDto>(user);
            var albumDtos = _mapper.Map<List<AlbumDto>>(albums);
            var postDtos = _mapper.Map<List<PostDto>>(posts);
            var commentDtos = _mapper.Map<List<CommentDto>>(comments);

            foreach (var postDto in postDtos)
            {
                postDto.Comments = commentDtos.Where(c => c.PostId == postDto.Id).ToList();
            }

            foreach (var albumDto in albumDtos)
            {
                albumDto.Posts = postDtos.Where(p => p.AlbumId == albumDto.Id).ToList();
            }

            userDto.Albums = albumDtos;

            // (Optional: If posts can exist outside of albums, you can add them to a separate list)

            return userDto;
        }
    }
}