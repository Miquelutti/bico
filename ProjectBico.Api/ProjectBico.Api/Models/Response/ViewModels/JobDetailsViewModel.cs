namespace ProjectFatec.WebApi.Models.Response.ViewModels
{
    public class JobDetailsViewModel : JobViewModel
    {
        public virtual long JobCategoryId { get; set; }

        public UserViewModel Provider { get; set; }
        public int IsActive { get; set; }
    }
}