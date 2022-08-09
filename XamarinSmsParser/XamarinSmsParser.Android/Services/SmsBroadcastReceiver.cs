using Android.App;
using Android.Content;
using Android.Provider;
using Android.Util;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinSmsParser.Droid.Services
{
    [BroadcastReceiver(Enabled = true, Exported = true, Permission = "android.permission.BROADCAST_SMS")]
    [IntentFilter(
        new[] { "android.provider.Telephony.SMS_RECEIVED", "android.provider.Telephony.SMS_DELIVER" },
        Priority = (int)IntentFilterPriority.HighPriority)]
    public class SmsBroadcastReceiver : BroadcastReceiver
    {
        public SmsBroadcastReceiver()
        {

        }

        public override void OnReceive(Context context, Intent intent)
        {
            var msgs = Telephony.Sms.Intents.GetMessagesFromIntent(intent);

            var msgList = new List<string>();
            foreach (var msg in msgs)
            {
                msgList.Add(msg.DisplayMessageBody);

                string address = "";
                string body = "";
                MarkMessageRead(Android.App.Application.Context, address, body);

            }

            MessagingCenter.Send<List<string>>(msgList, "MyMessage");
        }

        public void MarkMessageRead(Context context, string number, string body)
        {
            var uri = Android.Net.Uri.Parse("content://sms/inbox");
            var cursor = context.ContentResolver.Query(uri, null, null, null, null);
            try
            {
                while (cursor.MoveToNext())
                {
                    if ((cursor.GetString(cursor.GetColumnIndex("address")).Equals(number)) && (cursor.GetInt(cursor.GetColumnIndex("read")) == 0))
                    {
                        if (cursor.GetString(cursor.GetColumnIndex("body")).StartsWith(body))
                        {
                            var SmsMessageId = cursor.GetString(cursor.GetColumnIndex("_id"));
                            var values = new ContentValues();
                            values.Put("read", true);
                            context.ContentResolver.Update(Android.Net.Uri.Parse("content://sms/inbox"), values, "_id=" + SmsMessageId, null);
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("Mark Read", "Error in Read: " + e.ToString());
            }
        }
    }
}