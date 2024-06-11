using FinanceApplication.icons;
using System;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceApplication.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        private bool lastnumber = false;
        public Calculator()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            Arase.Source = ImageSource.FromResource(Icons.Iconspath[19]);
        }

        private void Arase_Clicked(object sender, EventArgs e)
        {
            result.Text = "";
            if (!string.IsNullOrEmpty(text.Text))  
                text.Text = text.Text.Substring(0, text.Text.Length - 1);
            if (text.Text.Length == 1) text.Text = "";
        }

        private void number_clicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                text.Text += button.Text;
                lastnumber = true;
            }
        }

        private void operation_clicked(object sender, EventArgs e)
        {
            if (sender is Button button && lastnumber)
            {
                text.Text += button.Text;
                lastnumber = false;
            }
        }

        private void CalculateFromString(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text.Text))
            {

                var dataTable = new DataTable();
                try
                {
                    var result1 = dataTable.Compute(text.Text, "");
                    result.Text = Convert.ToDouble(result1).ToString();
                    Console.WriteLine("sdfasfsadafwefewef");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка при вычислении выражения: " + ex.Message);
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            result.Text = "";
            text.Text = "";
        }
    }
}