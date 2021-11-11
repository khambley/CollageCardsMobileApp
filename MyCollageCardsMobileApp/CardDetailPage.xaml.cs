using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class CardDetailPage : ContentPage, INotifyPropertyChanged
    {
        int CardId;
        public CardDetailPage(int cardId)
        {
            InitializeComponent();
            CardId = cardId;
        }


    }
}
