using Microsoft.Intune.MAM;

namespace MauiApplication
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;

        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.IsIntuneActive = true;

            bool hasEnrolledAccount = viewModel.HasEnrolledAccount();

            if(hasEnrolledAccount)
            {
                viewModel.AccountDetail = IntuneMAMEnrollmentManager.Instance.EnrolledAccountId;
                viewModel.AccountDetailIsReadOnly = true;
            }
            else
            {
                viewModel.AccountDetail = "";
                viewModel.AccountDetailIsReadOnly = false;
            }
        }
    }

}
