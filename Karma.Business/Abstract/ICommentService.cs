using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetAll();
        List<Comment> GetListByProductId(int ProductId);
        Comment GetById(int Id);
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
    }
}
