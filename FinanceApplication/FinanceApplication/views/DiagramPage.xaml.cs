using FinanceApp.classes;
using FinanceApplication.core;
using Microcharts;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DiagramPage : ContentPage
	{
        public DiagramPage()
        {
            InitializeComponent();
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);

            List<ExtendedCategory> extendedCategories = (from category in Context.Categories
                                                         join color in Context.Colors on category.ColorId equals color.ColorId
                                                         select new ExtendedCategory(category.Name, color.DarkMode, category.IconId, category.CategoryId, Context.User.UserId, category.ColorId, category.IsProfit)).ToList();

            List<ChartEntry> entries = new List<ChartEntry>();

            foreach (ExtendedCategory category in extendedCategories)

                entries.Add(new ChartEntry((float)category.CategorySum) {
                    Color = SKColor.Parse(category.DarkMode),
                    Label = category.Name,
                } 
           );

            foreach (ChartEntry item in entries)
            {
                StackLayout legendItem = new StackLayout { Orientation = StackOrientation.Horizontal };
                BoxView colorBax = new BoxView { 
                    WidthRequest = 10, 
                    HeightRequest = 10, 
                    Color = item.Color.ToFormsColor() 
                };
                Label label = new Label { Text = item.Label, TextColor = Color.Black };

                legendItem.Children.Add(colorBax);
                legendItem.Children.Add(label);

                CategoriesLegend.Children.Add(legendItem);

                Console.WriteLine($"цвет {item.Color}  лэбл {item.ValueLabel}  лэйбл1 {item.Label} {item.Value}");
            }


            Chart3.Chart = new DonutChart() { Entries = entries, LabelMode = LabelMode.None};
        }
    }
}