using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EGStore.Application.DTO;
using EGStore.Application.Interface;
using EGStore.Domain.Entities;
using EGStore.Domain.Repositories;

namespace EGStore.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepo _blogRepo;
        private readonly IMapper _mapper;
        public BlogService(IBlogRepo blogRepo, IMapper mapper)
        {
            _blogRepo = blogRepo;
            _mapper = mapper;
        }
        public bool AddBlog(BlogDTO blogDTO)
        {
            blogDTO.UpDay = DateTime.Now;
            blogDTO.UpdateDay = DateTime.Now;
            return _blogRepo.Add(_mapper.Map<Blog>(blogDTO));
        }

        public List<BlogDTO> GetAllBlogs()
        {
            return _mapper.Map<List<BlogDTO>>(_blogRepo.GetAll());
        }

        public BlogDTO GetBlogById(Guid id)
        {
            return _mapper.Map<BlogDTO>(_blogRepo.Get(id));
        }

        public bool UpdateBlog(BlogDTO blogDTO)
        {
            return _blogRepo.Update(_mapper.Map<Blog>(blogDTO));
        }

        public bool DeleteBlog(Guid id)
        {
            return _blogRepo.Delete(id);
        }
    }
}
