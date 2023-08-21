using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Karma.MvcUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public IActionResult Index(Comment comment)
        {
            _commentService.Add(comment);
            string referans = Request.Headers["Referer"].ToString();
            return Redirect(referans);
        }
    }
}
