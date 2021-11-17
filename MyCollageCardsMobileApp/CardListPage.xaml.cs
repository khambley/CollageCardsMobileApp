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

                string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                var theCardList = dataContext.Cards.ToList();

                if(theCardList.Count > 2)
                { 
                    foreach (var path in theCardList.Skip(2))
                    { 
                        path.ImagePath = documentsFolder + path.ImagePath;
                    }
                }
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
                    ImagePath = "64F5C59E-059A-485D-98CB-F6CA6512B6D0.jpeg",
                    DateCreated = DateTime.Now
                });
                await context.AddAsync(new Card
                {
                    Title = "My Collage Card 2",
                    Suit = "Test Suit 2",
                    Description = "This is a test card description",
                    ImagePath = "B489B79B-A0CE-4A6F-AD75-FFCF8A675099.jpeg",
                    DateCreated = DateTime.Now
                });
                await context.AddAsync(new Note
                {
                    DateCreated = DateTime.Now,
                    Text = "This is a new note",
                    CardId = 1
                });
                await context.AddAsync(new Note
                {
                    DateCreated = DateTime.Now,
                    Text = "This is another new note",
                    CardId = 1
                });
                await context.AddAsync(new Note
                {
                    DateCreated = DateTime.Now,
                    Text = "This is a new note",
                    CardId = 2
                });
                await context.AddAsync(new Note
                {
                    DateCreated = DateTime.Now,
                    Text = "This is another note",
                    CardId = 2
                });
                await context.SaveChangesAsync();
            }
        }

        async void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            var addCardPage = new AddCardPage();
            await Navigation.PushAsync(addCardPage);
        }

        async void cardCollectionView_SelectionChanged(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Card card))
                return;

            var cardDetailPage = new CardDetailPage(card.Id);
            await Navigation.PushAsync(cardDetailPage);
        }
    }
}
