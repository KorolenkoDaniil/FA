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
        Context context = new Context();
        public DiagramPage(Context context)
        {
            InitializeComponent();
            this.context = context;

            List<ExtendedCategory> extendedCategories = (from category in context.Categories
                                                         join color in context.Colors on category.ColorId equals color.ColorId
                                                         select new ExtendedCategory(category.Name, color.DarkMode, color.LightMode, category.IconId, category.CategoryId, context.User.UserId, category.ColorId)).ToList();

            List<ChartEntry> entries = new List<ChartEntry>();

            foreach (ExtendedCategory category in extendedCategories)

                entries.Add(new ChartEntry((float)category.CategorySum) {
                    Color = SKColor.Parse(category.LightMode),
                    Label = category.Name,
                } 
           );

            foreach (ChartEntry item in entries)
            {
                StackLayout legendItem = new StackLayout { Orientation = StackOrientation.Horizontal };
                BoxView colorBax = new BoxView { WidthRequest = 10, HeightRequest = 10, Color = item.Color.ToFormsColor() };
                Label label = new Label { Text = item.Label, TextColor = Color.Black };

                legendItem.Children.Add(colorBax);
                legendItem.Children.Add(label);

                CategoriesLegend.Children.Add(legendItem);

                Console.WriteLine($"цвет {item.Color}  лэбл {item.ValueLabel}  лэйбл1 {item.Label}  {item.Value}");
            }


            Chart3.Chart = new DonutChart() { Entries = entries, LabelMode = LabelMode.None};
        }
    }
}