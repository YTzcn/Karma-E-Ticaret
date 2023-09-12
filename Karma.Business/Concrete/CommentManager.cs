using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.ExceptionsLogAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public Comment GetById(int Id)
        {
            return _commentDal.Get(x => x.Id == Id);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public List<Comment> GetAll()
        {
            return _commentDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(Comment comment)
        {
            _commentDal.Update(comment);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public List<Comment> GetListByProductId(int ProductId)
        {
            return _commentDal.GetList(x => x.ProductId == ProductId);
        }
    }
}
