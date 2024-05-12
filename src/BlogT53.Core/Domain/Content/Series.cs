namespace BlogT53.Core.Domain.Content
{
    public class Series
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public string? SeoDescription { get; set; }
        public string? Thumbnail { set; get; }
        public string? Content { get; set; }
        public Guid AuthorUserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}