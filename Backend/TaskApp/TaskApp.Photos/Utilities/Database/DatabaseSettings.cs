namespace TaskApp.Photos.Utilities.Database
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string PhotosCollectionName { get; set; }
    }
}
