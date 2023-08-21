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
        List<Comment> GetList(Expression<Func<Comment, bool>> filter = null);
        Comment Get(Expression<Func<Comment, bool>> filter = null);
        void Add(Comment comment);
        void Delete(Comment comment);
        void Update(Comment comment);
    }
}
