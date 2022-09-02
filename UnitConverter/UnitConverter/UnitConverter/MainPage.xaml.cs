using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UnitConverter
{
    //public static class Constant
    //{
    //    public static readonly string categoryDefault = "Сategory";
    //    public static readonly string categoryLength = "Length";
    //    public static readonly string categoryWeight = "Weight";
    //    public static readonly string categorySpeed = "Speed";
    //}
    public partial class MainPage : ContentPage
    {
        private Picker categoryPicker;

        private Picker processedPicker;

        private Picker rawPicker;

        private StackLayout pickersLayout;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            StackLayout mainLayout = new StackLayout();
            mainLayout.Padding = new Thickness(5, 5, 5, 5);

            Label appName = new Label();
            appName.Text = "Converter";
            appName.HorizontalOptions = LayoutOptions.Center;

            categoryPicker = new Picker
            {

            };

            pickersLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            rawPicker = new Picker
            {
                Title = "Unit"
            };

            rawPicker.SelectedIndexChanged += rawPicker_SelectedIndexChanged;

            processedPicker = new Picker
            {
                Title = "Unit"
            };

            processedPicker.SelectedIndexChanged += processedPicker_SelectedIndexChanged;

            pickersLayout.Children.Add(rawPicker);
            pickersLayout.Children.Add(processedPicker);

            mainStackLayout.Children.Add(pickersLayout);

            // new:

            mainLayout.Children.Add(appName);
            Content = mainLayout;
        }
        void rawPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            rawPicker.Title = rawPicker.Items[rawPicker.SelectedIndex];
        }
        void processedPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            processedPicker.Title = processedPicker.Items[processedPicker.SelectedIndex];
        }
        void categoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryPicker.Title = categoryPicker.Items[categoryPicker.SelectedIndex];
            switch (categoryPicker.Items[categoryPicker.SelectedIndex])
            {
                case "Length":
                    rawPicker.Items.Clear();
                    rawPicker.Items.Add("inch");
                    rawPicker.Items.Add("sm");
                    rawPicker.Items.Add("foot");
                    rawPicker.Items.Add("m");

                    processedPicker.Items.Clear();
                    processedPicker.Items.Add("inch");
                    processedPicker.Items.Add("sm");
                    processedPicker.Items.Add("foot");
                    processedPicker.Items.Add("m");
                    break;
                case "Weight":
                    rawPicker.Items.Clear();
                    rawPicker.Items.Add("pud");
                    rawPicker.Items.Add("kg");
                    rawPicker.Items.Add("ounces");
                    rawPicker.Items.Add("mg");

                    processedPicker.Items.Clear();
                    processedPicker.Items.Add("pud");
                    processedPicker.Items.Add("kg");
                    processedPicker.Items.Add("ounces");
                    processedPicker.Items.Add("mg");
                    break;
                case "Speed":
                    rawPicker.Items.Clear();
                    rawPicker.Items.Add("m/s");
                    rawPicker.Items.Add("km/h");
                    rawPicker.Items.Add("miles/h");
                    rawPicker.Items.Add("nodes");

                    processedPicker.Items.Clear();
                    processedPicker.Items.Add("m/s");
                    processedPicker.Items.Add("km/h");
                    processedPicker.Items.Add("miles/h");
                    processedPicker.Items.Add("nodes");
                    break;
                default:
                    break;
            }
        }
    }
}
