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

        public Item(string name)
        {
            POG = name;
        }

        public override string ToString()
        {
            return this.POG;
        }

    }


    public partial class MainPage : ContentPage
    {
        ObservableCollection<Item> Items = new ObservableCollection<Item>();
        List<Xamarin.Forms.Shapes.Rectangle> Previous_Selections = new List<Xamarin.Forms.Shapes.Rectangle>();
        List<Xamarin.Forms.Image> Highlighted_Arrows = new List<Image>();

        void Fill_Items()
        {
            Items.Clear();

            // PLUGS
            // Index 0
            Item Spark_Plugs = new Item("PLUGS - Spark Plugs");
            Xamarin.Forms.Shapes.Rectangle Spark_Plug_Location = LOC5_PLUGS;
            Items.Add(Spark_Plugs);

            // BATTERY
            // Index 1
            Item Battery = new Item("BATTERY - Batteries");
            Xamarin.Forms.Shapes.Rectangle Battery_Location = LOC5_BATTERY;
            Items.Add(Battery);


            // CLUTCHES
            Item Clutches = new Item("STARTER - Starters");
            Xamarin.Forms.Shapes.Rectangle Starter_Location = LOC5_STARTER;
            Items.Add(Clutches); 
            
            //GASKETS
            Item Gaskets = new Item("GASKETS - Gaskets");
            Xamarin.Forms.Shapes.Rectangle Gaskets_Location = LOC5_GASKETS1;
            Xamarin.Forms.Shapes.Rectangle Gaskets_Location2 = LOC5_GASKETS2;
            Items.Add(Gaskets);

            //BATTERY1522
            Item Battery1522 = new Item("BATT1522 - Batteries");
            Xamarin.Forms.Shapes.Rectangle Battery1522_Location = LOC5_BATTERY1522;
            Items.Add(Battery1522);





            // casts the list as every item
            Match_List();
        }

        void Highlight_Areas(string POG_Name)
        {
            if (POG_Name == "PLUGS - Spark Plugs")
            {
                LOC5_PLUGS.IsVisible = true;
                Previous_Selections.Add(LOC5_PLUGS);
            }

            else if (POG_Name == "BATTERY - Batteries")
            {
                LOC5_BATTERY.IsVisible = true;
                Previous_Selections.Add(LOC5_BATTERY);
            }

            else if (POG_Name == "STARTER - Starters")
            {
                LOC5_STARTER.IsVisible = true;
                Previous_Selections.Add(LOC5_STARTER);
                Center_Left_Arrow.IsVisible = true;
                Highlighted_Arrows.Add(Center_Left_Arrow);

            }

            else if (POG_Name == "GASKETS - Gaskets")
            {
                LOC5_GASKETS1.IsVisible = true;
                LOC5_GASKETS2.IsVisible = true;

                Previous_Selections.Add(LOC5_GASKETS2);
                Previous_Selections.Add(LOC5_GASKETS1);
            }
            
            else if (POG_Name == "BATT1522 - Batteries")
            {
                LOC5_BATTERY1522.IsVisible = true;
                Previous_Selections.Add(LOC5_BATTERY1522);
                Center_Left_Arrow.IsVisible = true;
                Highlighted_Arrows.Add(Center_Left_Arrow);
            }

            return;
        }


        // function mostly used for testing purposes. Prune later
        void Match_List()
        {
            POG_List.ItemsSource = Items;
        }

        void Clear_Areas()
        {
            for (int i = 0; i < Previous_Selections.Count(); i++)
            {
                Previous_Selections[i].IsVisible = false;
            }

            for (int i = 0; i < Highlighted_Arrows.Count(); i++)
            {
                Highlighted_Arrows[i].IsVisible = false;
            }

            Highlighted_Arrows.Clear();
            Previous_Selections.Clear();
        }
    }
}