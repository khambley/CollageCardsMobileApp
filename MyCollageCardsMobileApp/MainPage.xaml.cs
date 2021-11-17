using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollageCardsMobileApp.Models;
using MyCollageCardsMobileApp.Services;
using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            
        }
        async void ViewCardsButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var cardListPage = new CardListPage();
            await Navigation.PushAsync(cardListPage);
        }

        async void SendFeedbackButton_Clicked(Object send, EventArgs e)
        {
            var feedbackPage = new FeedbackPage();
            var localDesignPage = new LocalDesignPage();
            var dynamicResourcePage = new DynamicResourcePage();
            var importResourcesPage = new ImportResourcesPage();
            await Navigation.PushAsync(importResourcesPage);
        }


    }
}
