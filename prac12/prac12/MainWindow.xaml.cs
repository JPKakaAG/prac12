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

namespace prac12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ContextMenu inputDataContextMenu;
        private ContextMenu resultContextMenu;
        public MainWindow()
        {
            InitializeComponent();
            InitializeContextMenu();
        }
        private void InitializeContextMenu()
        {
            // Создаем контекстное меню для блока "Исходные данные"
            inputDataContextMenu = new ContextMenu();

            // Создаем пункт меню "Очистить"
            MenuItem clearMenuItem = new MenuItem();
            clearMenuItem.Header = "Очистить";
            clearMenuItem.Click += ClearInputs_Click;
            inputDataContextMenu.Items.Add(clearMenuItem);

            // Назначаем контекстное меню блоку "Исходные данные"
            GIntial.ContextMenu = inputDataContextMenu;

            // Создаем контекстное меню для блока "Результат"
            resultContextMenu = new ContextMenu();
            MenuItem clearRezItem = new MenuItem();
            clearRezItem.Header = "Очистить";
            clearRezItem.Click += ClearRezult_Click;
            // Назначаем контекстное меню блоку "Результат"
            GRezult.ContextMenu = resultContextMenu;
        }

        private void ClearInputs_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем значения текстовых полей блока "Исходные данные"
            tbX1.Text = "";
            tbX2.Text = "";
            tbY1.Text = "";
            tbY2.Text = "";
            tbNum.Text = "";
        }
        private void ClearRezult_Click(object sender, RoutedEventArgs e)
        {
            lb1.Items.Clear();
            tblStatus.Text = "";
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbX1.Text, out double x1) && double.TryParse(tbX2.Text, out double x2) && double.TryParse(tbY1.Text, out double y1) && double.TryParse(tbY2.Text, out double y2) && int.TryParse(tbNum.Text, out int number))
            {
                // Устанавливаем фокус на первый элемент блока "Исходные данные"
                tbX1.Focus();

                lb1.Items.Add($"x1 = {x1}, x2 = {x2}, y1 = {y1}, y2 = {y2}, {number} байт");
                // Вычисляем длину и ширину прямоугольника
                double width = Math.Abs(x2 - x1);
                double height = Math.Abs(y2 - y1);

                // Вычисляем периметр и площадь прямоугольника
                double perimeter = 2 * (width + height);
                double area = width * height;

                // Выводим результаты на экран
                lb1.Items.Add($"Периметр: {perimeter}\r\nПлощадь: {area}");

     

                // Вычисляем количество полных килобайтов
                number = number / 1024;

                // Выводим результат на экран

                lb1.Items.Add($"Размер в килобайтах: {number}");

                // Обновляем строку статуса
                tblStatus.Text = $"Задача #13 | {DateTime.Now:dd.MM.yyyy HH:mm:ss}";

                tbX1.Text = "";
                tbX2.Text = "";
                tbY1.Text = "";
                tbY2.Text = "";
                tbNum.Text = "";
            }
            else
            {
                MessageBox.Show("Введите числа");
            }

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Выполнил лучший разработчик: Девяткин Вадим Евгеньевич\r\nПрактическая №12 \r\n\r\nДаны координаты двух противоположных вершин прямоугольника: (x1, y1), (x2, y2).\r\nСтороны прямоугольника параллельны осям координат. Найти периметр и площадь данного прямоугольника.\r\n\r\nДан размер файла в байтах. Используя операцию деления нацело, найти количество полных килобайтов, которые занимает данный файл (1 килобайт = 1024 байта)");
        }
    }
}
