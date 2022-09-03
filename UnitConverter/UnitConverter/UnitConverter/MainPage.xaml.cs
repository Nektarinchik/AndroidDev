using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace UnitConverter
{
    public partial class MainPage : ContentPage
    {
        private Picker categoryPicker;

        private Picker processedPicker;

        private Picker rawPicker;

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

        private Label rawValueLabel;

        private Label processedValueLabel;

        //private Label rawValueLabel;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            StackLayout mainLayout = new StackLayout();
            mainLayout.Padding = new Thickness(5, 5, 5, 5);

            Label appName = new Label
            {
                Text = "Converter",
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 30.0,
                TextColor = Color.Black
            };

            categoryPicker = new Picker
            {
                Title = "Category",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
            };

            categoryPicker.Items.Add("Length");
            categoryPicker.Items.Add("Weight");
            categoryPicker.Items.Add("Speed");
            categoryPicker.SelectedIndexChanged += categoryPicker_SelectedIndexChanged;

            Grid pickers = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };

            rawPicker = new Picker
            {
                Title = "0",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
            };

            rawPicker.SelectedIndexChanged += rawPicker_SelectedIndexChanged;

            processedPicker = new Picker
            {
                Title = "0",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
            };

            processedPicker.SelectedIndexChanged += processedPicker_SelectedIndexChanged;

            Image imageSwitch = new Image
            {
                Source = ImageSource.FromResource("UnitConverter.Images.switch.png")
            };

            pickers.Children.Add(rawPicker, 0, 0);
            pickers.Children.Add(imageSwitch, 1, 0);
            pickers.Children.Add(processedPicker, 2, 0);

            Grid values = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition()
                }
            };

            Frame rawValue = new Frame
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                CornerRadius = 8,
                HorizontalOptions = LayoutOptions.Center,
            };
            rawValueLabel = new Label 
            {
                Text = "0",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
            };
            rawValue.Content = rawValueLabel;

            Label equalLabel = new Label
            {
                Text = "=",
                FontAttributes = FontAttributes.Bold,
                FontSize = 35.0,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Frame processedValue = new Frame
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                CornerRadius = 8,
                HorizontalOptions = LayoutOptions.Center,
            };
            processedValueLabel = new Label
            {
                Text = "0",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
            };
            processedValue.Content = processedValueLabel;

            values.Children.Add(rawValue, 0, 0);
            values.Children.Add(equalLabel, 1, 0);
            values.Children.Add(processedValue, 2, 0);

            Grid buttons = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition(),
                    new RowDefinition()
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

            mainLayout.Children.Add(appName);
            mainLayout.Children.Add(categoryPicker);
            mainLayout.Children.Add(pickers);
            mainLayout.Children.Add(values);
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
