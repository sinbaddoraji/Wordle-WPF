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
using DictionarySearch;

namespace Wordle
{
    /// <summary>
    /// Interaction logic for WordleLine.xaml
    /// </summary>
    public partial class WordleLine : UserControl
    {
        public static string Word = "FLESH";
        public int block = 0; // line 0 to 4
        TextBox[] blocks;


        public WordleLine()
        {
            InitializeComponent();
            
            blocks = new[]
            {
                tx1, tx2, tx3, tx4, tx5
            };
        }

        public string GetWordAttempt()
        {
            return $"{tx1.Text}{tx2.Text}{tx3.Text}{tx4.Text}{tx5.Text}";
        }

        private void SetWord(string word)
        {
            tx1.Text = word[0].ToString();
            tx2.Text = word[1].ToString();
            tx3.Text = word[2].ToString();
            tx4.Text = word[3].ToString();
            tx5.Text = word[4].ToString();
        }

        public void WriteWord(string chunck)
        {
            if (block < 5)
            {
                blocks[block].Text = chunck;
                block++;
            }
        }

        public void Backspace()
        {
            blocks[block].Text = "";

            if (block > 0)
                block--;
        }

        public bool Enter()
        {
            string word = GetWordAttempt();
            bool isValidWord = WordleDictionary.IsWord(word);
            if (isValidWord)
            {
                foreach (TextBox txt in blocks)
                {
                    Update(txt);
                }

                return true;
            }
            else
            {
                return false;
            }
           
        }

        public void Reset()
        {
            SetWord("     ");
            block = 0;
        }

        private void Update(TextBox txt)
        {
            var txtBox = ((TextBox)txt);
            string str = txtBox.Name.Substring(2, 1);

            int.TryParse(str, out int index);

            if (Word[index - 1].ToString() == txtBox.Text)
            {
                txtBox.Foreground = Brushes.LightGreen;
            }
            else if (Word.Contains(txtBox.Text))
            {
                txtBox.Foreground = Brushes.Yellow;
            }
            else
            {
                txtBox.Foreground = Brushes.Black;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
