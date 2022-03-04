using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wordle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Load Dictionary
            WordleDictionary.Initalize();

            //Reset game
            Reset();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            game.WriteWord((string)button.Content);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Enter
            game.Enter();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            //Back
            game.Backspace();
        }

        private void Reset()
        {
            game.Reset();
        }
    }
}
