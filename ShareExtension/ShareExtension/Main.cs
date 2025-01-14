﻿using UIKit;

namespace ShareExtension
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.

            Logger.Log(Logger.LogLevel.Info, "ShareExtension uygulaması başlatıldı.");

            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}