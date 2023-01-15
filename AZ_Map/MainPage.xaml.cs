using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;

namespace AZ_Map
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Test();

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            POG_List.ItemsSource = Items.Where(s => s.POG.Contains(e.NewTextValue));

        }

        private void Pog_List_Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            if (item != null)
            {
                if (Previous_Selection!= null)
                {
                    Previous_Selection.IsVisible = false;
                }
                Previous_Selection = item.Location;
                Previous_Selection.IsVisible = true;
            }
            else
            {
                Previous_Selection = item.Location;
                Previous_Selection.IsVisible = true;
            }
        }















        //*************************************************************************************
        // pinch zoom code that we ripped from
        // https://www.c-sharpcorner.com/article/pinch-gesture-in-xamarin-forms-application-for-android-and-uwp/
        // it kinda works. Revisit later


        private double startScale;
        private double currentScale;
        private double xOffset;
        private double yOffset;
        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);
                Content.TranslationX = Math.Min(0, Math.Max(targetX, -Content.Width * (currentScale - 1)));
                Content.TranslationY = Math.Min(0, Math.Max(targetY, -Content.Height * (currentScale - 1)));
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }



        //*************************************************************************************




    }
}
