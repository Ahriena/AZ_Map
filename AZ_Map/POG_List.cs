using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AZ_Map
{
    class Item
    {
        public string POG;
        public Xamarin.Forms.Shapes.Rectangle Area_5_Location;

        public override string ToString()
        {
            return this.POG;
        }

    }


    public partial class MainPage : ContentPage
    {
        ObservableCollection<Item> Items = new ObservableCollection<Item>();
        Xamarin.Forms.Shapes.Rectangle Previous_Selection_Area_5 = null;



        void Fill_Items()
        {
            Item Spark_Plugs = new Item();
            Spark_Plugs.POG = "PLUGS - Spark Plugs";
            Xamarin.Forms.Shapes.Rectangle Spark_Plug_Location = Area_5_Row_2;
            Spark_Plugs.Area_5_Location = Spark_Plug_Location;
            Items.Add(Spark_Plugs);

            Item Battery = new Item();
            Battery.POG = "BATTERY - Batteries";
            Xamarin.Forms.Shapes.Rectangle Battery_Location = Area_5_Column_1;
            Battery.Area_5_Location = Battery_Location;
            Items.Add(Battery);

            Item Clutches = new Item();
            Clutches.POG = "STARTER - Starters";
            Xamarin.Forms.Shapes.Rectangle Starter_Location = Area_5_Column_2;
            Clutches.Area_5_Location = Battery_Location;
            Items.Add(Clutches);
        }

        


        void Test()
        {
            Fill_Items();

            POG_List.ItemsSource = Items;
            
        }
    }
}