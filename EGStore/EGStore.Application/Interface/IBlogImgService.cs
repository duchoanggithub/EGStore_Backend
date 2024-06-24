using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IBlogImgService
    {
        List<BlogImgDTO> GetAllBlogImgs();
        BlogImgDTO GetBlogImgById(Guid id);
        bool AddBlogImg(BlogImgDTO blogImgDTO);
        bool UpdateBlogImg(BlogImgDTO blogImgDTO);
        bool DeleteBlogImg(Guid id);
    }
}
