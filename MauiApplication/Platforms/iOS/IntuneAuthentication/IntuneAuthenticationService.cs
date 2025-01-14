using System;
using MauiApplication.Services;
using Microsoft.Intune.MAM;

namespace MauiApplication.Platforms.iOS.IntuneAuthentication;

public class IntuneAuthenticationService : IIntuneAuthenticationService
{
    public Task<bool> LoginAndEnrollAsync(string accountName)
    {
        IntuneMAMEnrollmentManager.Instance.LoginAndEnrollAccount(accountName);
        return Task.FromResult(true);
    }
    public Task SignOutAsync()
    {
        var enrolledAccountId = IntuneMAMEnrollmentManager.Instance.EnrolledAccountId;
        if (!string.IsNullOrWhiteSpace(enrolledAccountId))
        {
            IntuneMAMEnrollmentManager.Instance.DeRegisterAndUnenrollAccountId(enrolledAccountId, true);
        }
        return Task.CompletedTask;
    }
}
