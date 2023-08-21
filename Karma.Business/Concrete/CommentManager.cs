using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public Comment Get(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.Get(filter);
        }

        public List<Comment> GetList(Expression<Func<Comment, bool>> filter = null)
        {
            return _commentDal.GetList(filter);
        }

        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
