namespace Fatec.Domain.ValueTypes.AppSettings
{
    public interface IAppSettings
    {
        ConnectionStrings ConnectionStrings { get; set; }
        public string Secret { get; set; }
        public string Name { get; set; }
    }
}
