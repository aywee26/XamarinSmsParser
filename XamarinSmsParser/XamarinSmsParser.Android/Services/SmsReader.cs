using Android.App;
using Android.Content;
using XamarinSmsParser.Droid.Services;
using XamarinSmsParser.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(SmsReader))]
namespace XamarinSmsParser.Droid.Services
{
    public class SmsReader : ISmsReader
    {
        public void GetSmsInbox()
        {
            var filter = new IntentFilter();
            filter.AddAction("android.provider.Telephony.SMS_RECEIVED");

            var receiver = new SmsBroadcastReceiver();
            Application.Context.RegisterReceiver(receiver, filter);
        }
    }
}