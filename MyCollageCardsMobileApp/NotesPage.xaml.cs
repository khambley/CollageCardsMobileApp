using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class NotesPage : ContentPage, INotifyPropertyChanged
    {
        int CardId;

        public NotesPage(int cardId)
        {
            CardId = cardId;
            InitializeComponent();
        }
    }
}
