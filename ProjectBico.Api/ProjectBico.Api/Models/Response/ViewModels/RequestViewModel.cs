namespace ProjectFatec.WebApi.Models.Response.ViewModels
{
    public class RequestViewModel
    {
        public virtual long Id { get; set; }
        public UserViewModel ContractingUser { get; set; }
        public string Description { get; set; }
        public JobDetailsViewModel Job { get; set; }
        public virtual long RequestStatusId { get; set; }
    }
}
