using System;
using MauiApplication.Services;

namespace MauiApplication.Platforms.Android.IntuneAuthentication;

public class IntuneAuthenticationService : IIntuneAuthenticationService
{
    public Task<bool> LoginAndEnrollAsync(string accountName)
    {
        return Task.FromResult(true);
    }
    public Task SignOutAsync()
    {
        return Task.CompletedTask;
    }
}