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
        public Xamarin.Forms.Shapes.Rectangle Location;

        public override string ToString()
        {
            return this.POG;
        }

    }


    public partial class MainPage : ContentPage
    {
        ObservableCollection<Item> Items = new ObservableCollection<Item>();
        Xamarin.Forms.Shapes.Rectangle Previous_Selection = null;



        void Fill_Items()
        {
            Item Spark_Plugs = new Item();
            Spark_Plugs.POG = "PLUGS - Spark Plugs";
            Xamarin.Forms.Shapes.Rectangle Spark_Plug_Location = Area_5_Row_2;
            Spark_Plugs.Location = Spark_Plug_Location;
            Items.Add(Spark_Plugs);

            Item Battery = new Item();
            Battery.POG = "BATTERY - Batteries";
            Xamarin.Forms.Shapes.Rectangle Battery_Location = Area_5_Column_1;
            Battery.Location = Battery_Location;
            Items.Add(Battery);

            Item Clutches = new Item();
            Clutches.POG = "STARTER - Starters";
            Xamarin.Forms.Shapes.Rectangle Starter_Location = Area_5_Column_2;
            Clutches.Location = Starter_Location;
            Items.Add(Clutches); 
            
            Item Gaskets = new Item();
            Gaskets.POG = "GASKETS - Gaskets";
            Xamarin.Forms.Shapes.Rectangle Gaskets_Location = Area_5_Row_1;
            Gaskets.Location = Gaskets_Location;
            Items.Add(Gaskets);


        }

        


        void Test()
        {
            Fill_Items();

            POG_List.ItemsSource = Items;
            
        }
    }
}