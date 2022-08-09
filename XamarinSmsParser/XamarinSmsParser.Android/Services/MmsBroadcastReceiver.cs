using Android.Content;
using Android.Widget;

namespace XamarinSmsParser.Droid.Services
{
    public class MmsBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
        }
    }
}