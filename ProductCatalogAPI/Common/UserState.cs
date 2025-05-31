namespace ProductCatalogAPI.Common
{
    public sealed record UserState
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
