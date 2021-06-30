namespace GraphQLChocolate.API.Settings
{
    public class AppSettings
    {
        public AppSettingsToken TokenSettings { get; set; }
    }

    public class AppSettingsToken
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Authority { get; set; }
    }
}
