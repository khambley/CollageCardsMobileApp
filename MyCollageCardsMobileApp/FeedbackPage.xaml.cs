using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class FeedbackPage : ContentPage
    {
        const string placeholderText = "Type your message here.";

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

        public FeedbackPage()
        {
            InitializeComponent();
            Feedback.Text = (string)Resources["FeedbackPlaceholder"];
            Feedback.TextColor = (Color)Resources["InputPlaceholderColor"];
        }
    }
}
