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

        private string currentCategory;

        private Picker processedPicker;

        private Picker rawPicker;

        private StackLayout pickersLayout;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            currentCategory = null;
            //StackLayout layout = new StackLayout();

            //Label label1 = new Label();
            //label1.Text = "Converter";
            //label1.TextColor = Color.SkyBlue;
            //label1.FontSize = 20;
            //label1.HorizontalOptions = LayoutOptions.Center;

            //picker = new Picker
            //{
            //    Title = "Unit"
            //};
            //picker.Items.Add("Length");
            //picker.Items.Add("Weight");
            //picker.Items.Add("Speed");
            //picker.SelectedIndexChanged += picker_SelectedIndexChanged;

            //layout.Children.Add(label1);
            //layout.Children.Add(picker);

            //Content = layout;

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

            rawPicker.SelectedIndexChanged += processedPicker_SelectedIndexChanged;

            pickersLayout.Children.Add(rawPicker);
            pickersLayout.Children.Add(processedPicker);

            mainStackLayout.Children.Add(pickersLayout);
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
                    currentCategory = "Length";
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
                    currentCategory = "Weight";
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
                    currentCategory = "Speed";
                    break;
                default:
                    break;
            }
        }
    }
}
