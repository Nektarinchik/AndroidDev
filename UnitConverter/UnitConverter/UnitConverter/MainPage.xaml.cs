using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using UnitConverter.Converter;
using Android.App;
using Android.Content.PM;
using ControlSamples.Effects;

namespace UnitConverter
{
    public partial class MainPage : ContentPage
    {

        //private Image imageSwitch;
        private String processedValueStr;

        private StringBuilder rawValueStr;

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

        private Button buttonCopy;

        private Button buttonPaste;

        private ImageButton buttonPop;

        private ImageButton buttonSwitch;

        private Entry rawValueEntry;

        private Label equalLabel;

        private Entry processedValueEntry;

        private Label appName;

        private StackLayout mainLayout;

        private Grid buttons;

        private Grid pickers;

        private Grid values;

        private Grid copyPasteGrid;

        private double width = 0;

        private double height = 0;
        public MainPage()
        {
            InitializeComponent();
            width = Width;
            height = Height;
        }
        protected override void OnAppearing()
        {
            rawValueStr = new StringBuilder();
            mainLayout = new StackLayout
            {
                Padding = new Thickness(5, 5, 5, 5),
                BackgroundColor = Color.White,
            };

            appName = new Label
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

            pickers = new Grid
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

            buttonSwitch = new ImageButton
            {
                Source = ImageSource.FromResource("UnitConverter.Images.switch.png"),
                BackgroundColor = Color.White,
                IsVisible = false
            };
            buttonSwitch.Clicked += ButtonSwitch_Clicked;

            pickers.Children.Add(rawPicker, 0, 0);
            pickers.Children.Add(buttonSwitch, 1, 0);
            pickers.Children.Add(processedPicker, 2, 0);

            values = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition()
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                }
            };

            rawValueEntry = new Entry
            {
                Placeholder = "0",
                Text = "",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center
            };
            rawValueEntry.Effects.Add(new NoKeyboardEffect());
            equalLabel = new Label
            {
                Text = "=",
                FontAttributes = FontAttributes.Bold,
                FontSize = 35.0,
                TextColor = Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };
            processedValueEntry = new Entry
            {
                Placeholder = "0",
                Text = "",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                HorizontalTextAlignment = TextAlignment.Center,
                IsReadOnly = true
            };

            values.Children.Add(rawValueEntry, 0, 0);
            values.Children.Add(equalLabel, 1, 0);
            values.Children.Add(processedValueEntry, 2, 0);

            copyPasteGrid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(),
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition(),
                    new ColumnDefinition(),
                }
            };

            buttonCopy = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "Copy",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(0)
            };
            buttonCopy.Clicked += ButtonCopy_Clicked;

            buttonPaste = new Button
            {
                BorderColor = Color.Gray,
                BackgroundColor = Color.FromHex("#e1e1e1"),
                Text = "Paste",
                FontAttributes = FontAttributes.Bold,
                FontSize = 20.0,
                TextColor = Color.Black,
                Margin = new Thickness(0),
                Padding = new Thickness(0)
            };
            buttonPaste.Clicked += ButtonPaste_Clicked;

            copyPasteGrid.Children.Add(buttonPaste, 0, 0);
            copyPasteGrid.Children.Add(buttonCopy,  1, 0);

            buttons = new Grid
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
                Padding = new Thickness(0)
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
            mainLayout.Children.Add(copyPasteGrid);
            mainLayout.Children.Add(buttons);
            Content = mainLayout;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;

                UpdateLayout();
            }
        }

        private void UpdateLayout()
        {
            if (Width > Height)
            {
                SetupLandscapeLayout();
            }
            else
            {
                SetupPortraitLayout();
            }
        }
        private void SetupLandscapeLayout()
        {
            mainLayout.Orientation = StackOrientation.Horizontal;
            StackLayout leftPart = new StackLayout();
            leftPart.Orientation = StackOrientation.Vertical;
            leftPart.Children.Add(appName);
            leftPart.Children.Add(categoryPicker);
            leftPart.Children.Add(pickers);
            leftPart.Children.Add(values);
            leftPart.Children.Add(copyPasteGrid);
            mainLayout.Children.Clear();
            mainLayout.Children.Add(buttons);
            mainLayout.Children.Add(leftPart);
            Content = mainLayout;
        }
        private void SetupPortraitLayout()
        {
            mainLayout.Orientation = StackOrientation.Vertical;
            mainLayout.Children.Clear();
            mainLayout.Children.Add(appName);
            mainLayout.Children.Add(categoryPicker);
            mainLayout.Children.Add(pickers);
            mainLayout.Children.Add(values);
            mainLayout.Children.Add(copyPasteGrid);
            mainLayout.Children.Add(buttons);
            Content = mainLayout;
        }

        private async void ButtonPaste_Clicked(object sender, EventArgs e)
        {
            if (Clipboard.HasText)
            {
                try
                {
                    string buff = await Clipboard.GetTextAsync();
                    Convert.ToDouble(buff);
                    if (buff.Length > 15 || buff.Contains("E"))
                        throw new OverflowException();
                    rawValueStr.Clear();
                    rawValueStr.Append(buff);
                    if (categoryPicker.SelectedIndex != -1 && rawPicker.SelectedIndex != -1)
                    {
                        CategoryConverter categoryConverter =
                        CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                        categoryConverter.UnitConverter =
                            UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                        double processedValue = categoryConverter.Convert(
                            processedPicker.Items[processedPicker.SelectedIndex],
                            rawValueStr.ToString()
                            );
                        processedValueStr = processedValue.ToString();
                        processedValueEntry.Text = processedValueStr;
                        rawValueEntry.Text = rawValueStr.ToString();
                    }
                    else
                    {
                        rawValueEntry.Text = rawValueStr.ToString();
                    }
                }
                catch (FormatException)
                {
                    await DisplayAlert("Incorrect value", "", "Ok");
                }
                catch (OverflowException)
                {
                    await DisplayAlert("Too much value", "", "Ok");
                }
            }
        }
        private async void ButtonCopy_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(processedValueStr))
                await Clipboard.SetTextAsync(processedValueStr);
            else
                await Clipboard.SetTextAsync("0");
        }
        private async void ButtonSwitch_Clicked(object sender, EventArgs e)
        {
            if (!processedValueStr.Contains("E"))
            {
                processedPicker.SelectedIndexChanged -= processedPicker_SelectedIndexChanged;
                rawPicker.SelectedIndexChanged -= rawPicker_SelectedIndexChanged;
                int temp = processedPicker.SelectedIndex;
                processedPicker.SelectedIndex = rawPicker.SelectedIndex;
                rawPicker.SelectedIndex = temp;
                processedPicker.SelectedIndexChanged += processedPicker_SelectedIndexChanged;
                rawPicker.SelectedIndexChanged += rawPicker_SelectedIndexChanged;
                rawValueStr.Clear();
                rawValueStr.Append(processedValueStr);

                if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
                {
                    rawPicker_SelectedIndexChanged(sender, e);
                    processedPicker_SelectedIndexChanged(sender, e);
                }
            }
            else
                await DisplayAlert("Too much value", "", "Ok");
        }
        private void ButtonPop_Clicked(object sender, EventArgs e)
        {
            if (!rawValueStr.Equals("0") && !string.IsNullOrEmpty(rawValueStr.ToString()))
            {
                if (rawValueEntry.CursorPosition != 0)
                    rawValueStr.Remove(rawValueEntry.CursorPosition - 1, 1);
                else
                    return;

                if (rawValueStr.Length == 0) rawValueStr.Append("0");

                int temp = rawValueEntry.CursorPosition - 1;
                rawValueEntry.Text = rawValueStr.ToString();
                rawValueEntry.CursorPosition = temp;
                rawValueEntry.CursorPosition = temp; 
                if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
                {
                    try
                    {
                        CategoryConverter categoryConverter = 
                            CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                        categoryConverter.UnitConverter =
                            UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                        double processedValue = categoryConverter.Convert(
                            processedPicker.Items[processedPicker.SelectedIndex],
                            rawValueStr.ToString()
                            );
                        processedValueStr = processedValue.ToString();
                        processedValueEntry.Text = processedValueStr;
                    }
                    catch (ArgumentException)
                    {
                        rawValueStr.Clear();
                        rawValueEntry.Text = "";
                        processedValueEntry.Text = "";
                    }

                }
            }
        }
        private void ButtonClearAll_Clicked(object sender, EventArgs e)
        {
            rawValueStr.Clear();
            processedValueStr = "";
            rawValueEntry.Text = "";
            processedValueEntry.Text = "";
        }
        private async void ButtonPoint_Clicked(object sender, EventArgs e)
        {

            if (!rawValueStr.ToString().Contains("."))
            {
                if (rawValueStr.Length == 15)
                {
                    await DisplayAlert("too much Value", "", "Ok");
                }
                else if (rawValueStr.Length == 14) return;
                else if (string.IsNullOrEmpty(rawValueStr.ToString()))
                {
                    rawValueStr.Append("0.");
                    rawValueEntry.Text = rawValueStr.ToString();
                    rawValueEntry.CursorPosition = 2;
                }
                else
                {
                    if (rawValueEntry.CursorPosition != 0)
                    {
                        rawValueStr.Insert(rawValueEntry.CursorPosition, ".");
                        int temp = rawValueEntry.CursorPosition + 1;
                        rawValueEntry.Text = rawValueStr.ToString();
                        rawValueEntry.CursorPosition = temp;
                        rawValueEntry.CursorPosition = temp;
                        if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
                        {
                            CategoryConverter categoryConverter =
                                CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                            categoryConverter.UnitConverter =
                                UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                            double processedValue = categoryConverter.Convert(
                                processedPicker.Items[processedPicker.SelectedIndex],
                                rawValueStr.ToString()
                                );
                            processedValueStr = processedValue.ToString();
                            processedValueEntry.Text = processedValueStr;
                        }
                    }
                }
            }
            else
                return;
        }
        private async void ButtonZero_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "0");
            }
            else
            {
                if (rawValueEntry.CursorPosition != 0)
                    rawValueStr.Insert(rawValueEntry.CursorPosition, "0");
                else
                    return;
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }
        private async void ButtonNine_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "9");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "9");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }
        private async void ButtonEight_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "8");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "8");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonSeven_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "7");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "7");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonSix_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "6");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "6");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonFive_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "5");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "5");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonFour_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "4");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "4");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonThree_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "3");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "3");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonTwo_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "2");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "2");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
        }

        private async void ButtonOne_Clicked(object sender, EventArgs e)
        {
            string buff = rawValueStr.ToString();
            if (buff.Equals("0"))
            {
                buff = "";
                rawValueStr.Clear();
                rawValueEntry.CursorPosition = 0;
            }

            if (rawValueEntry.Text.Contains(".") && !rawValueStr.ToString().Contains("."))
            {
                rawValueStr.Append(".");
                rawValueStr.Insert(rawValueEntry.CursorPosition, "1");
            }
            else
            {
                rawValueStr.Insert(rawValueEntry.CursorPosition, "1");
            }

            if (rawValueStr.Length == 16)
            {
                rawValueStr.Clear();
                rawValueStr.Append(buff);
                await DisplayAlert("Too much value", "", "Ok");
            }
            int temp = rawValueEntry.CursorPosition + 1;
            rawValueEntry.Text = rawValueStr.ToString();
            rawValueEntry.CursorPosition = temp;
            rawValueEntry.CursorPosition = temp;
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
            }
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
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
                rawValueEntry.Text = rawValueStr.ToString();
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
            if (rawPicker.SelectedIndex != -1 && processedPicker.SelectedIndex != -1)
            {
                CategoryConverter categoryConverter =
                    CategoryConverterFactory.CreateCategoryConverter(categoryPicker.Items[categoryPicker.SelectedIndex]);
                categoryConverter.UnitConverter =
                    UnitConverterFactory.CreateUnitConverter(rawPicker.Items[rawPicker.SelectedIndex]);
                double processedValue = categoryConverter.Convert(
                    processedPicker.Items[processedPicker.SelectedIndex],
                    rawValueStr.ToString()
                    );
                processedValueStr = processedValue.ToString();
                processedValueEntry.Text = processedValueStr;
                rawValueEntry.Text = rawValueStr.ToString();
            }
        }
        void categoryPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoryPicker.Title = categoryPicker.Items[categoryPicker.SelectedIndex];
            switch (categoryPicker.Items[categoryPicker.SelectedIndex])
            {
                case "Length":
                    rawPicker.Items.Clear();
                    rawPicker.Items.Add("dm");
                    rawPicker.Items.Add("sm");
                    rawPicker.Items.Add("mm");
                    rawPicker.Items.Add("m");

                    processedPicker.Items.Clear();
                    processedPicker.Items.Add("dm");
                    processedPicker.Items.Add("sm");
                    processedPicker.Items.Add("mm");
                    processedPicker.Items.Add("m");
                    break;
                case "Weight":
                    rawPicker.Items.Clear();
                    rawPicker.Items.Add("centner");
                    rawPicker.Items.Add("kg");
                    rawPicker.Items.Add("g");
                    rawPicker.Items.Add("mg");

                    processedPicker.Items.Clear();
                    processedPicker.Items.Add("centner");
                    processedPicker.Items.Add("kg");
                    processedPicker.Items.Add("g");
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

            if (!rawPicker.IsVisible && !processedPicker.IsVisible && !buttonSwitch.IsVisible)
            {
                rawPicker.IsVisible = true;
                processedPicker.IsVisible = true;
                buttonSwitch.IsVisible = true;
            }

            rawValueStr.Clear();
            rawValueStr.Append("0");
            processedValueStr = "";
            rawValueEntry.Text = "";
            processedValueEntry.Text = "";
        }
    }
}
