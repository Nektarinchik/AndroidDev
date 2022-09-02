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

        private StackLayout valuesLayout;

        private Button buttonOne;

        private Button buttonTwo;

        private Button buttonThree;

        private Button buttonFour;

        private Button buttonFive;

        private Button buttonSix;

        private Button buttonSeven;

        private Button buttonEight;

        private Button buttonNine;

        private Button buttonPoint;

        private Button buttonZero;

        private Button buttonClearAll;

        private Button buttonPop;

        //private Label rawValueLabel;
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
                Title = "Category"
            };
            categoryPicker.Items.Add("Length");
            categoryPicker.Items.Add("Weight");
            categoryPicker.Items.Add("Speed");
            categoryPicker.SelectedIndexChanged += categoryPicker_SelectedIndexChanged;

            valuesLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            Frame rawValue = new Frame
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                CornerRadius = 8,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new Label { Text = "0" }
            };

            Frame processedValue = new Frame
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                CornerRadius = 8,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Content = new Label { Text = "0" }
            };

            valuesLayout.Children.Add(rawValue);
            valuesLayout.Children.Add(processedValue);

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

            Grid buttons = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };

            buttonOne = new Button
            {
                BackgroundColor = Color.Black,
                Text = "1",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonTwo = new Button
            {
                BackgroundColor = Color.Black,
                Text = "2",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonThree = new Button
            {
                BackgroundColor = Color.Black,
                Text = "3",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonFour = new Button
            {
                BackgroundColor = Color.Black,
                Text = "4",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonFive = new Button
            {
                BackgroundColor = Color.Black,
                Text = "5",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonSix = new Button
            {
                BackgroundColor = Color.Black,
                Text = "6",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonSeven = new Button
            {
                BackgroundColor = Color.Black,
                Text = "7",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonEight = new Button
            {
                BackgroundColor = Color.Black,
                Text = "8",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonNine = new Button
            {
                BackgroundColor = Color.Black,
                Text = "9",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonPoint = new Button
            {
                BackgroundColor = Color.Black,
                Text = ".",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonZero = new Button
            {
                BackgroundColor = Color.Black,
                Text = "0",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonClearAll = new Button
            {
                BackgroundColor = Color.Black,
                Text = "C",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttonPop = new Button
            {
                BackgroundColor = Color.Black,
                Text = "-",
                TextColor = Color.White,
                Margin = new Thickness(5),
            };

            buttons.Children.Add(buttonOne,      0, 0);
            buttons.Children.Add(buttonTwo,      1, 0);
            buttons.Children.Add(buttonThree,    2, 0);
            buttons.Children.Add(buttonFour,     0, 1);
            buttons.Children.Add(buttonFive,     1, 1);
            buttons.Children.Add(buttonSix,      2, 1);
            buttons.Children.Add(buttonSeven,    0, 2);
            buttons.Children.Add(buttonEight,    1, 2);
            buttons.Children.Add(buttonNine,     2, 2);
            buttons.Children.Add(buttonPoint,    0, 3);
            buttons.Children.Add(buttonZero,     1, 3);
            buttons.Children.Add(buttonClearAll, 2, 3);
            buttons.Children.Add(buttonPop,      0, 4);
            Grid.SetColumnSpan(buttonPop, 3);

            // new:

            mainLayout.Children.Add(appName);
            mainLayout.Children.Add(categoryPicker);
            mainLayout.Children.Add(pickersLayout);
            mainLayout.Children.Add(valuesLayout);
            mainLayout.Children.Add(buttons);
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
