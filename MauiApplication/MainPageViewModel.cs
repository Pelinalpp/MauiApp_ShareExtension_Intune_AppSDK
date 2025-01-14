using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApplication.Helpers;
using MauiApplication.Models;
using MauiApplication.Services;
using Microsoft.Intune.MAM;

namespace MauiApplication;

public partial class MainPageViewModel : ObservableObject
{
    [ObservableProperty]
    List<Item> items;

    [ObservableProperty]
    string accountDetail;

    [ObservableProperty]
    bool isIntuneActive = false;

    [ObservableProperty]
    bool accountDetailIsReadOnly;

    public bool HasEnrolledAccount()
    {
        return !(IntuneMAMEnrollmentManager.Instance.EnrolledAccountId == null || IntuneMAMEnrollmentManager.Instance.EnrolledAccountId.Length == 0);
    }

    [RelayCommand]
    public async void Login()
    {
        var intuneService = ServiceHelper.GetService<IIntuneAuthenticationService>();
        var intuneLoginResult = await intuneService.LoginAndEnrollAsync(AccountDetail);

        if(intuneLoginResult)
        {
            AccountDetailIsReadOnly = true;
        }
        else
        {
            AccountDetail = "";
            AccountDetailIsReadOnly = false;
        }
    }

    [RelayCommand]
    public async void Logout()
    {
        var intuneService = ServiceHelper.GetService<IIntuneAuthenticationService>();
        await intuneService.SignOutAsync();
        
        AccountDetail = "";
        AccountDetailIsReadOnly = false;
    }

}
