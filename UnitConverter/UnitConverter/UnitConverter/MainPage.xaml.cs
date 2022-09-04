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

        private Image imageSwitch;

        private StringBuilder rawValueStr;

        private StringBuilder processedValueStr;
        //private double rawValue;

        //private double processedValue;

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

        //private Button buttonPop;

        private ImageButton buttonPop;

        private Label rawValueLabel;

        private Label processedValueLabel;
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            rawValueStr = new StringBuilder();
            processedValueStr = new StringBuilder();
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
                IsVisible = false
            };

            rawPicker.SelectedIndexChanged += rawPicker_SelectedIndexChanged;

            processedPicker = new Picker
            {
                Title = "0",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                IsVisible = false
            };

            processedPicker.SelectedIndexChanged += processedPicker_SelectedIndexChanged;

            imageSwitch = new Image
            {
                Source = ImageSource.FromResource("UnitConverter.Images.switch.png"),
                IsVisible = false
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
                LineBreakMode = LineBreakMode.HeadTruncation
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
                LineBreakMode = LineBreakMode.HeadTruncation
            };
            processedValue.Content = processedValueLabel;

            values.Children.Add(rawValue, 0, 0);
            values.Children.Add(equalLabel, 1, 0);
            values.Children.Add(processedValue, 2, 0);

            Grid buttons = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition{ Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition{ Width = new GridLength(1, GridUnitType.Star) }
                },
                BackgroundColor = Color.FromHex("#FFFFFF")
            };

            buttonOne = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "1",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonOne.Clicked += ButtonOne_Clicked;

            buttonTwo = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "2",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonTwo.Clicked += ButtonTwo_Clicked;

            buttonThree = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "3",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonThree.Clicked += ButtonThree_Clicked;

            buttonFour = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "4",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonFour.Clicked += ButtonFour_Clicked;

            buttonFive = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "5",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonFive.Clicked += ButtonFive_Clicked;

            buttonSix = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "6",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonSix.Clicked += ButtonSix_Clicked;

            buttonSeven = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "7",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonSeven.Clicked += ButtonSeven_Clicked;

            buttonEight = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "8",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonEight.Clicked += ButtonEight_Clicked;

            buttonNine = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "9",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonNine.Clicked += ButtonNine_Clicked;
            
            buttonPoint = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = ".",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonPoint.Clicked += ButtonPoint_Clicked;

            buttonZero = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "0",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonZero.Clicked += ButtonZero_Clicked;

            buttonClearAll = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "C",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonClearAll.Clicked += ButtonClearAll_Clicked;

            buttonPop = new ImageButton
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Source = ImageSource.FromResource("UnitConverter.Images.back.png"),
                Margin = new Thickness(0),
                Padding = new Thickness(30)
            };
            buttonPop.Clicked += ButtonPop_Clicked;

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
        private void ButtonPop_Clicked(object sender, EventArgs e)
        {
            if (!rawValueStr.Equals("0") && !string.IsNullOrEmpty(rawValueStr.ToString()))
            {
                string buffs = rawValueStr.ToString();
                rawValueStr.Clear();
                rawValueStr.Append(buffs.Substring(0, buffs.Length - 1));
                //try
                //{
                //    rawValue = Convert.ToDouble(buff);
                //}
                //catch (FormatException)
                //{
                //    rawValue = 0.0;
                //}
                rawValueLabel.Text = rawValueStr.ToString();
            }
        }

        private void ButtonClearAll_Clicked(object sender, EventArgs e)
        {
            rawValueStr.Clear();
            rawValueLabel.Text = "0";
        }
        private async void ButtonPoint_Clicked(object sender, EventArgs e)
        {
            //string buff = rawValue.ToString();

            //if (!buff.Contains("."))
            //{
            //    if (buff.Length == 15)
            //    {
            //        await DisplayAlert("Value is too much", "", "Ok");
            //    }
            //    else if (buff.Equals("0"))
            //    {
            //        rawValueLabel.Text += ".";
            //    }
            //    else
            //    {
            //        if (!rawValueLabel.Text.Contains("."))
            //        {
            //            // comma hasnt been yet
            //            rawValueLabel.Text += ".";
            //        }
            //        else
            //        {
            //            return;
            //        }
            //    }
            //}
        }
        private async void ButtonZero_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("0");
            }
            else
            {
                rawValueStr.Append("0");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }
        private async void ButtonNine_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("9");
            }
            else
            {
                rawValueStr.Append("9");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }
        private async void ButtonEight_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("8");
            }
            else
            {
                rawValueStr.Append("8");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonSeven_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("7");
            }
            else
            {
                rawValueStr.Append("7");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonSix_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("6");
            }
            else
            {
                rawValueStr.Append("6");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonFive_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("5");
            }
            else
            {
                rawValueStr.Append("5");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonFour_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("4");
            }
            else
            {
                rawValueStr.Append("4");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonThree_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("3");
            }
            else
            {
                rawValueStr.Append("3");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonTwo_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("2");
            }
            else
            {
                rawValueStr.Append("2");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        private async void ButtonOne_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
            }

            if (rawValueLabel.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Append("1");
            }
            else
            {
                rawValueStr.Append("1");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Value is too much", "", "Ok");
            }
            rawValueLabel.Text = rawValueStr.ToString();
        }

        void rawPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rawPicker.Items.Count == 0)
            {
                rawPicker.Title = "0";
            }
            else
            {
                rawPicker.Title = rawPicker.Items[rawPicker.SelectedIndex];
            }
        }
        void processedPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (processedPicker.Items.Count == 0)
            {
                processedPicker.Title = "0";
            }
            else
            {
                processedPicker.Title = processedPicker.Items[processedPicker.SelectedIndex];
            }
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

            if (!rawPicker.IsVisible && !processedPicker.IsVisible && !imageSwitch.IsVisible)
            {
                rawPicker.IsVisible = true;
                processedPicker.IsVisible = true;
                imageSwitch.IsVisible = true;
            }
        }
    }
}
