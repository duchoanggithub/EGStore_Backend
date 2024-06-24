using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGStore.Application.DTO;

namespace EGStore.Application.Interface
{
    public interface IBlogService
    {
        List<BlogDTO> GetAllBlogs();
        BlogDTO GetBlogById(Guid id);
        bool AddBlog(BlogDTO blogDTO);
        bool UpdateBlog(BlogDTO blogDTO);
        bool DeleteBlog(Guid id);
    }
}
