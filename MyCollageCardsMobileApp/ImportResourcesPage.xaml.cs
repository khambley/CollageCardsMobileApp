using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class ImportResourcesPage : ContentPage
    {
        void HandleFeedback(object sender, FocusEventArgs e)
        {
            var placeHolderText = (string)Resources["FeedbackPlaceholder"];
            if (Feedback.Text == placeHolderText)
            {
                Feedback.Text = string.Empty;
                Feedback.TextColor = (Color)Resources["InputTextColor"];
                return;
            }
            if (Feedback.Text == string.Empty)
            {
                Feedback.Text = placeHolderText;
                Feedback.TextColor = (Color)Resources["InputPlaceholderColor"];
                return;
            }
        }

        void HandleSubject(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if (Subject.Text == string.Empty)
            {
                Resources["PageBgColor"] = Resources["PageBgColorNoSubject"];
                Resources["BtSubmitColor"] = Resources["BtInactiveColor"];
            }
            else
            {
                Resources["PageBgColor"] = Resources["PageBgColorWithSubject"];
                Resources["BtSubmitColor"] = Resources["BtSubmitActiveColor"];
            }
        }
        public ImportResourcesPage()
        {
            InitializeComponent();
            Feedback.Text = (string)Resources["FeedbackPlaceholder"];
            Feedback.TextColor = (Color)Resources["InputPlaceholderColor"];
            Subject.Text = string.Empty;
            Resources["PageBgColor"] = Resources["PageBgColorNoSubject"];
            Resources["BtSubmitColor"] = Resources["BtInactiveColor"];
        }
    }
}
