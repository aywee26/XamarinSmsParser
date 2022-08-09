using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinSmsParser.Interfaces;

namespace XamarinSmsParser
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<List<string>>(this, "MyMessage", (expense) =>
            {
                var myList = expense as List<string>;
                string allText = "";
                foreach (var item in myList)
                {
                    allText += item + " ";
                }
                editorSms.Text = allText;
            });
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            DependencyService.Get<ISmsReader>().GetSmsInbox();
        }
    }
}
