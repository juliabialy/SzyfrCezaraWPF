using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace SzyfrCezaraWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encrypt_Click(object sender, RoutedEventArgs e)
        {
            int key;

            if (!int.TryParse(KeyTextBox.Text, out key))
            {
                key = 0; 
            }

            string text = InputTextBox.Text;
            OutputTextBlock.Text = CaesarCipher(text, key);
        }

        private string CaesarCipher(string text, int key)
        {
            key %= 26;
            char[] result = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == ' ')
                {
                    result[i] = ' ';
                }
                else
                {
                    int shifted = c + key;

                    if (shifted > 'z')
                        shifted -= 26;
                    if (shifted < 'a')
                        shifted += 26;

                    result[i] = (char)shifted;
                }
            }

            return new string(result);
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Pliki tekstowe (*.txt)|*.txt";

            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, OutputTextBlock.Text);
            }
        }
    }
}
