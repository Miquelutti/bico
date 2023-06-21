namespace Fatec.Domain.ValueTypes.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
    }
}
