namespace Fatec.Domain.ValueTypes.AppSettings
{
    public class AppSettings : IAppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
}
