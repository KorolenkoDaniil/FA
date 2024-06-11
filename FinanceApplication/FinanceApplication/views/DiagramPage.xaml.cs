using Android.Accounts;
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
            NavigationPage.SetHasNavigationBar(this, false);
            back.BackgroundColor = Color.FromHex(Context.User.AppModeColor);

            List<ExtendedCategory> extendedCategories = (from category in Context.Categories
                                                         join color in Context.Colors on category.ColorId equals color.ColorId
                                                         select new ExtendedCategory(category.Name, color.DarkMode, category.IconId, category.CategoryId, Context.User.UserId, category.ColorId, category.IsProfit)).ToList();

            List<ChartEntry> entries1 = new List<ChartEntry>();
            List<ChartEntry> entries2 = new List<ChartEntry>();

            decimal sum = 0;

            foreach (ExtendedCategory category in extendedCategories.Where(exCat => exCat.IsProfit))
            {
                entries1.Add(new ChartEntry((float)category.CategorySum)
                {
                    Color = SKColor.Parse(category.DarkMode),
                    Label = category.Name,
                });

                sum += category.CategorySum;
            }

            foreach (ChartEntry item in entries1)
            {
                StackLayout legendItem = new StackLayout { Orientation = StackOrientation.Horizontal };
                BoxView colorBax = new BoxView
                {
                    WidthRequest = 15,
                    HeightRequest = 10,
                    Color = item.Color.ToFormsColor()
                };
                Label label = new Label { Text = item.Label, TextColor = Color.Black };

                legendItem.Children.Add(colorBax);
                legendItem.Children.Add(label);

                CategoriesLegend.Children.Add(legendItem);

                Console.WriteLine($"цвет {item.Color} лэбл {item.ValueLabel}  лэйбл1 {item.Label} {item.Value}");
            }

            if (sum == 0)
            {
                entries1.Add(new ChartEntry(1)
                {
                    Color = SKColor.Parse("#707070"),
                });
            }

            Amount.Text = sum.ToString();


            Chart3.Chart = new DonutChart() { Entries = entries1, LabelMode = LabelMode.None };





            sum = 0;

            foreach (ExtendedCategory category in extendedCategories.Where(exCat => !exCat.IsProfit))
            {
                entries2.Add(new ChartEntry((float)category.CategorySum)
                {
                    Color = SKColor.Parse(category.DarkMode),
                    Label = category.Name,
                });

                sum += category.CategorySum;
            }


            foreach (ChartEntry item in entries2)
            {
                StackLayout legendItem = new StackLayout { Orientation = StackOrientation.Horizontal };
                BoxView colorBax = new BoxView
                {
                    WidthRequest = 15,
                    HeightRequest = 10,
                    Color = item.Color.ToFormsColor()
                };
                Label label = new Label { Text = item.Label, TextColor = Color.Black };

                legendItem.Children.Add(colorBax);
                legendItem.Children.Add(label);

                CategoriesLegend2.Children.Add(legendItem);

                Console.WriteLine($"цвет {item.Color} лэбл {item.ValueLabel}  лэйбл1 {item.Label} {item.Value}");
            }

            Amount2.Text = sum.ToString();

            if (sum == 0)
            {
                entries2.Add(new ChartEntry(1)
                {
                    Color = SKColor.Parse("#707070"),
                });
            }

            Chart32.Chart = new DonutChart() { Entries = entries2, LabelMode = LabelMode.None };
        }
    }
}
