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
            Fill_Items();

        }

        // modifies search bar display in accordance with what is typed
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // casts everything as lower case then compares to prevent it being case sensitive
            POG_List.ItemsSource = Items.Where(s => s.POG.ToLower().Contains(e.NewTextValue.ToLower()));
        }

        // Highlights respective areas when a POG is selected
        private void Pog_List_Item_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            Clear_Areas();
            Highlight_Areas(POG_List.SelectedItem.ToString());

        }


    }
     
   
}
