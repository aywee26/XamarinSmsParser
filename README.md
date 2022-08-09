# XamarinSmsParser
A Xamarin Forms application that is capable of receiving SMS messages and can be set as default SMS app.

# Discaimer
All credits go to [Leon Lu](https://github.com/851265601/). I just recreated the project from the ground up.

# Purpose
Unfortunately, receiving SMS is not implemented in Xamarin Essentials library. Instead you have to implement this functionality yourself, using BroadcastReceiver class.

I found this whole process poorly documented and very confusing. So I started looking for implementations.

This solution, created by Leon Lu, is

1. As clean as it can get

2. Implements enough functionality, so the end result can be set as default SMS app.

# Known issues

- You need to grant SMS permission manually, in app settings.

# References

- Stack Overflow: [Creating Default SMS App in Xamarin.Forms](https://stackoverflow.com/questions/61451407/creating-default-sms-app-in-xamarin-forms)
