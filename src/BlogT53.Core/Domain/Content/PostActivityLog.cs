namespace BlogT53.Core.Domain.Content
{
    public class PostActivityLog
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public PostStatus FromStatus { set; get; }
        public PostStatus ToStatus { set; get; }
        public DateTime DateCreated { get; set; }
        public string? Note { set; get; }
        public Guid UserId { get; set; }
    }
}