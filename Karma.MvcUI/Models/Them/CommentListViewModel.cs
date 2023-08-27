using Karma.Entities.Concrete;

namespace Karma.MvcUI.Models.Them
{
    public class CommentListViewModel
    {
        public List<Comment> Comments { get; set; }
        public string Status { get; set; }
        public int ProductId { get; set; }
    }
}