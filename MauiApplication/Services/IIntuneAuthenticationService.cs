using System;

namespace MauiApplication.Services;

public interface IIntuneAuthenticationService
{
    Task<bool> LoginAndEnrollAsync(string accountName);
    Task SignOutAsync();
}
