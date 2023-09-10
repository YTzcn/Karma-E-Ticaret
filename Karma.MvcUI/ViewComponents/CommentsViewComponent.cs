using System.Drawing.Printing;
using Karma.Business.Abstract;
using Karma.Entities.Concrete;
using Karma.MvcUI.Models.Them;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.CodeAnalysis;

namespace Karma.MvcUI.ViewComponents
{
    public class CommentsViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentsViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public ViewViewComponentResult Invoke(int productId)
        {
            var comments = _commentService.GetListByProductId(productId);
            CommentListViewModel model = new CommentListViewModel
            {
                Comments = comments,
                ProductId = productId
            };
            return View(model);
        }

    }
}
