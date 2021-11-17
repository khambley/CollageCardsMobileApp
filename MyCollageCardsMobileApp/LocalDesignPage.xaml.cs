using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class LocalDesignPage : ContentPage
    {
        const string placeholderText = "Type your message here.";

        void HandleFeedback(object sender, FocusEventArgs e)
        {
            var text = Feedback.Text;
            if (Feedback.Text == placeholderText)
            {
                Feedback.Text = string.Empty;
                return;
            }
            if (Feedback.Text == string.Empty)
            {
                Feedback.Text = placeholderText;
                return;
            }
        }

        public LocalDesignPage()
        {
            InitializeComponent();
            Feedback.Text = placeholderText;
        }
    }
}
