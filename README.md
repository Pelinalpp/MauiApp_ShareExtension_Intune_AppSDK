# MauiApp_ShareExtension_Intune_AppSDK
This project was created to test the functionality of the Share Extension feature after integrating the Microsoft Intune App SDK into a MAUI (iOS) application with the Share Extension feature.

To test the application, follow these steps:

1) Signing the Application:
	(The issue with the Share Extension occurs on physical iOS devices, not on simulators. Therefore, the test must be conducted on a real device. For this reason, a development profile should be created with an Apple Developer account and used to sign the application. Here’s how to do it:)
	* Go to "developer.apple.com."
	* Under the "Identifiers" section, create an "App Group." Enter "group.com.mauiappintune" as the App Group ID.
	* Under the "Identifiers" section, create "App IDs" with the bundle IDs "com.mauiappintune" and "com.mauiappintune.share."
	* Enable "App Groups," "Associated Domains," and "MDM Managed Associated Domains" capabilities for these App IDs. Select the "group.com.mauiappintune" group created earlier as the App Group (do this for both App IDs).
	* Under the "Profiles" section, create development profiles for the "com.mauiappintune" and "com.mauiappintune.share" apps.
	* Sign the "MauiApplication" and "ShareExtension" projects in the "MauiApp_ShareExtension_Intune_AppSDK" GitHub repository using these profiles.
3) Creating an App in Azure:
	* Go to https://portal.azure.com and log in to your account.
	* Under the "App registrations" section, click the "New registration" button.
	* On the new registration page, configure the following settings and click "Register":
		- Enter an application name.
		- Select "Accounts in any organizational directory (Any Microsoft Entra ID tenant - Multitenant)" as the "Supported account types."
		- Leave the "Redirect URI" field empty.
	* On the next page, go to the "Certificates & Secrets" section and create a client secret. Note the "Secret ID" and "Value" at this stage.
	* From the left menu, go to Manage > Authentication.
	* Click the "Add a platform" button and select "iOS." Enter the following bundle ID: com.mauiappintune.
	* From the left menu, go to Manage > API permissions.
	* Click the "Add a Permission" button and add the following permissions:
		- From the "Microsoft Mobile Application Management" category: "DeviceManagementManagedApps.ReadWrite."
		- From the "Microsoft Graph" category: "User.Read."
	* After adding the permissions, click the "Grant Admin Consent" button to approve the permissions.
	* From the left menu, go to "Enterprise Applications." Select the application you created earlier and use the "Assign User and Groups" button to assign users or groups that will access the application.
	* Open the MauiApplication/Platforms/iOS/Info.plist file from the "MauiApp_ShareExtension_Intune_AppSDK" GitHub repository.
	* Under the IntuneMAMSettings key, replace <string>your-client-id</string> with the "Secret ID" value from Azure and save the file.
3) Adding an App Protection Policy in Intune:
	* Go to "intune.microsoft.com" and log in with your Intune account.
	* Under "Apps > Policy > App protection policies," create an iOS/iPadOS App Protection Policy by selecting "Create policy > iOS/iPadOS."
	* When configuring the iOS App Protection Policy, ensure the following settings:
		- Under "Apps," set "Target policy to" as "Selected apps."
		- Use the "Select custom apps" button to add com.mauiappintune as a custom app.
		- Use the "Select public apps" button to add the "Microsoft Outlook" application.
		- Under "Data protection," set "Send org data to other apps" as "Policy managed apps with Open-In/Share filtering."
	* After entering these settings, assign the policy to the Azure account/group you will use for testing.
4) Testing the Application:
	* Deploy the MAUI application to an iOS device.
	* Install the Microsoft Outlook app on the same device.
	* Log in to both the MAUI app and Outlook using an account configured with the App Protection Policy.
	* Share an image file with the MAUI application via the Share Extension, both from the device’s photo library and as an attachment from an email in Outlook. It can be observed that the image shared from the device’s photo library differs in size compared to the one shared from Outlook.

Despite both the Microsoft Outlook app and the MAUI app being managed by the Intune App SDK, files shared with the MAUI app via the Share Extension are not received correctly.
