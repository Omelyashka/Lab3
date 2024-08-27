using System;
using System.Collections.Generic;
using System.IO;
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

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    class PalindromeChecker
    {
        public bool IsPalindrome(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Невірний формат введених даних або порожній ввід.");

            // Приведення слова до нижнього регістру і видалення розділових символів
            string cleanedInput = new string(input.ToLower().Where(char.IsLetterOrDigit).ToArray());

            // Перевірка на паліндромність
            return cleanedInput.SequenceEqual(cleanedInput.Reverse());
        }
    }
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                // Створення екземпляра PalindromeChecker
                PalindromeChecker checker = new PalindromeChecker();
                // Отримання введеного користувачем тексту
                string input = TB.Text;
                // Виклик методу IsPalindrome для перевірки введеного тексту
                bool isPalindrome = checker.IsPalindrome(input);
                // Відображення результату перевірки на паліндромність
                if (isPalindrome)
                {
                    MessageBox.Show("Це слово є паліндромом.");
                }
                else
                {
                    MessageBox.Show("Це слово не є паліндромом.");
                }
            }
            catch (Exception ex)
            {
                // Відображення повідомлення про помилку, якщо виникла виняткова ситуація
                MessageBox.Show(ex.Message, "Помилка.");
            }

        }
    }
}
