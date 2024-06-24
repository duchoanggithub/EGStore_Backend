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
    public class BlogImgService : IBlogImgService
    {
        private readonly IBlogImgRepo _blogImgRepo;
        private readonly IMapper _mapper;
        public BlogImgService(IBlogImgRepo blogImgRepo, IMapper mapper)
        {
            _blogImgRepo = blogImgRepo;
            _mapper = mapper;
        }
        public bool AddBlogImg(BlogImgDTO blogImgDTO)
        {
            return _blogImgRepo.Add(_mapper.Map<BlogImg>(blogImgDTO));
        }

        public List<BlogImgDTO> GetAllBlogImgs()
        {
            return _mapper.Map<List<BlogImgDTO>>(_blogImgRepo.GetAll());
        }

        public BlogImgDTO GetBlogImgById(Guid id)
        {
            return _mapper.Map<BlogImgDTO>(_blogImgRepo.Get(id));
        }

        public bool UpdateBlogImg(BlogImgDTO blogImgDTO)
        {
            return _blogImgRepo.Update(_mapper.Map<BlogImg>(blogImgDTO));
        }

        public bool DeleteBlogImg(Guid id)
        {
            return _blogImgRepo.Delete(id);
        }
    }
}
