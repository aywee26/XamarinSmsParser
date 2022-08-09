using Android.App;
using Android.Content;
using Android.OS;

namespace XamarinSmsParser.Droid.Services
{
    public class HeadlessSmsSendService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}