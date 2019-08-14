using SampleWeb.Services.Samples.Models;

namespace SampleWeb.Services.Samples
{
    public interface ISampleDataService
    {
        FormWithFileViewModel GetFormWithFileViewModel();
        bool ProcessFormWithFileViewModel(FormWithFileViewModel model);
    }

    public class SampleDataService : ISampleDataService
    {
        public FormWithFileViewModel GetFormWithFileViewModel()
        {
            //Do special initialization here
            return new FormWithFileViewModel();
        }

        public bool ProcessFormWithFileViewModel(FormWithFileViewModel model)
        {
            //Do actual stuff here
            if (model.ProfilePhoto == null)
                return false;

            return true;
        }
    }
}
