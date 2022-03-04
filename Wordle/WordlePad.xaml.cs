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
    /// Interaction logic for WordlePad.xaml
    /// </summary>
    public partial class WordlePad : UserControl
    {

        int line = 0; //line 0 - 5
        WordleLine[] wordleLines;

        public WordlePad()
        {
            InitializeComponent();
            wordleLines = new[]
            {
                line1,line2,line3,line4,line5,line6
            };
        }

        public void Enter()
        {
            if (line < 5)
            {
                if (wordleLines[line].Enter())
                    line++;
                else
                {
                    MessageBox.Show($"{wordleLines[line].GetWordAttempt()} is not a word!");
                    wordleLines[line].Reset();
                }
            }
           
        }

        public void WriteWord(string input)
        {
            wordleLines[line].WriteWord(input);
        }

        public void Backspace()
        {
            wordleLines[line].Backspace();
        }

        public void Reset()
        {
            
            WordleLine.Word = WordleDictionary.RandomWord();
            line = 0;
            line1.Reset();
            line2.Reset();
            line3.Reset();
            line4.Reset();
            line5.Reset();
            line6.Reset();
        }

    }
}
