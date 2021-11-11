using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MyCollageCardsMobileApp.Models;
using MyCollageCardsMobileApp.Services;
using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class CardListPage : ContentPage, INotifyPropertyChanged
    {
        public CardListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            cardCollectionView.SelectedItem = null;

            using (var dataContext = new DataContext())
            {
                await InsertStartData(dataContext);

                var theCardList = dataContext.Cards.ToList();

                cardCollectionView.ItemsSource = theCardList;
            }
        }

        async Task InsertStartData(DataContext context)
        {
            var cardCount = context.Cards.Count();

            if (cardCount == 0)
            {
                await context.AddAsync(new Card
                {
                    Title = "My Collage Card 1",
                    Suit = "Test Suit 1",
                    Description = "This is a test card description",
                    ImagePath = "https://via.placeholder.com/500x800?text=Card+Image",
                    DateCreated = DateTime.Now
                });
                await context.AddAsync(new Card
                {
                    Title = "My Collage Card 2",
                    Suit = "Test Suit 2",
                    Description = "This is a test card description",
                    ImagePath = "https://via.placeholder.com/800x500?text=Card+Image",
                    DateCreated = DateTime.Now
                });
                await context.SaveChangesAsync();
            }
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new AddCardPage()));
        }

        async void cardCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(e.CurrentSelection.FirstOrDefault() is Card card))
                return;

            var cardDetailPage = new CardDetailPage(card.Id);
            await Navigation.PushAsync(cardDetailPage);
        }
    }
}
