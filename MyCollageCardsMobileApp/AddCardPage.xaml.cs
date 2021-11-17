using MyCollageCardsMobileApp.Models;
using MyCollageCardsMobileApp.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyCollageCardsMobileApp
{
    public partial class AddCardPage : ContentPage, INotifyPropertyChanged
    {
     
        string PhotoPath = null;

        public AddCardPage()
        {
            
            InitializeComponent();
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {
            if (PhotoPath != null)
            {
                var card = new Card
                {
                    Title = cardTitle.Text,
                    Suit = suitPicker.ItemsSource[suitPicker.SelectedIndex].ToString(),
                    Description = cardDescription.Text,
                    DateCreated = cardDateCreated.Date,
                    ImagePath = PhotoPath
                };
                using (var dataContext = new DataContext())
                {
                    dataContext.Add(card);

                    await dataContext.SaveChangesAsync();
                }
                await Navigation.PopAsync();
            }
        }   

        async void Cancel_Clicked(Object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        async void ChooseImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await PickerPhotoAsync();

            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
            //    return;
            //}
            //var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            //{
            //    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,

            //});

            //if (file == null)
            //    return;

            //resultImage.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});
   
        }

        
        async Task PickerPhotoAsync()
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Pick a photo"
                });
                var stream2 = await photo.OpenReadAsync();

                resultImage.Source = ImageSource.FromStream(() => stream2);

                await LoadPhotoAsync(photo);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
                await DisplayAlert("Permissions Not Granted", ":( Permission not granted to photos.", "OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }
        
        async Task LoadPhotoAsync(FileResult photo)
        {
            // cancelled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage

            // documents directory in app
            string documentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //char[] charArray = { 'D', 'o', 'c', 'u', 'm', 'e', 'n', 't', 's' };

            //string relativePath = documentsFolder.TrimEnd(charArray);

            //string relativePath = documentsFolder.Substring(documentsFolder.LastIndexOf("Documents"));
            //string relativePath = "";
            //int index = documentsFolder.LastIndexOf("Documents");
            //if(index > 0)
            //{
            //    //relativePath = documentsFolder.Substring(0, index);
            //    relativePath = documentsFolder.Substring(index);
                
            //}
            

            // images directory in documents directory in app
            string imagesFolder = Path.Combine(documentsFolder, "Images");

            // create images directory if it doesn't exist
            if(!Directory.Exists(documentsFolder + "Images"))
            {
                Directory.CreateDirectory(imagesFolder);
            }

            var newFile = Path.Combine(imagesFolder, photo.FileName);

            await DisplayAlert("File Location", newFile, "OK");

            using (Stream stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
            {
                await stream.CopyToAsync(newStream);

            }
            string[] separator = { "Documents" };
            string[] relativePaths = newFile.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
            string newfilePath = relativePaths[1];
            //sets file.Path for Save method to save path in db.
            PhotoPath = newfilePath;

            //PhotoPath = newFile;
        }

        async void CaptureImageButton_Clicked(System.Object sender, System.EventArgs e)
        {

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Test",
                AllowCropping = true,
                SaveToAlbum = true,
                CompressionQuality = 92,
                DefaultCamera = CameraDevice.Rear,

            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            resultImage.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                file.Dispose();
                return stream;
            });

            //var result = await MediaPicker.CapturePhotoAsync();

            //var stream = await result.OpenReadAsync();

            //resultImage.Source = ImageSource.FromStream(() => stream);

        }
    }
}
