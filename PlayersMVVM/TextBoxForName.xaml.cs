using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace PlayersMVVM
{
    public partial class TextBoxForName : UserControl
    {
        public TextBoxForName()
        {
            InitializeComponent();
        }

        //Copyrights: Adam Zielonka - 2020 - Politechnika Śląska
        public static readonly RoutedEvent TextChangedEvent =
           EventManager.RegisterRoutedEvent("Text_Changed", RoutingStrategy.Bubble,
               typeof(RoutedEventHandler), typeof(TextBoxForName));

        public event RoutedEventHandler TextChanged
        {
            add { AddHandler(TextChangedEvent, value); }
            remove { RemoveHandler(TextChangedEvent, value); }
        }

        void RaiseTextChanged()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(TextChangedEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxForName),
                new FrameworkPropertyMetadata(null));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void TextHasChanged(object sender, TextChangedEventArgs e)
        {

            if (!(sender is TextBox)) return;
            TextBox box = (TextBox)sender;
            if (box.Text == "")
            {
                box.BorderBrush = System.Windows.Media.Brushes.Red;
                box.BorderThickness = new Thickness(2);
                box.ToolTip = "Musisz uzupełnić pole!";
            }
            else
            {
                box.BorderBrush = System.Windows.Media.Brushes.Black;
                box.BorderThickness = new Thickness(1);
                box.ToolTip = null;
            }
            RaiseTextChanged();
        }

        private void IsFocused(object sender, RoutedEventArgs e)
        {
            if (!(sender is TextBox)) return;
            TextBox box = (TextBox)sender;
            if (box.Text == "Podaj imię" || box.Text == "Podaj nazwisko")
            {
                box.Foreground = Brushes.Black;
                box.Text = "";
            }
        }
    
    }
}
