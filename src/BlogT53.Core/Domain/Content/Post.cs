namespace BlogT53.Core.Domain.Content
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string? Thumbnail { get; set; }
        public string? Content { get; set; }
        public Guid AuthorUserId { get; set; }
        public string? Source { get; set; }
        public string? Tags { get; set; }
        public string? SeoDescription { get; set; }
        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsPaid { get; set; }
        public double RoyaltyAmount { get; set; }
        public PostStatus Status { get; set; }
    }

    public enum PostStatus
    {
        Draft = 1,
        Canceled = 2,
        WaitingForApproval = 3,
        Rejected = 4,
        WaitingForPublish = 5,
        Published = 6
    }
}