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
     
        }
        private void ClearRezult_Click(object sender, RoutedEventArgs e)
        {
     
        }
        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbX1.Text, out double x1) && double.TryParse(tbX2.Text, out double x2) && double.TryParse(tbX3.Text, out double x3) && double.TryParse(tbY1.Text, out double y1) && double.TryParse(tbY2.Text, out double y2) && double.TryParse(tbY3.Text, out double y3) && int.TryParse(tbNum.Text, out int number))
            {
                // Устанавливаем фокус на первый элемент блока "Исходные данные"
                tbX1.Focus();

                // Вычисляем длину и ширину прямоугольника
                double width = Math.Abs(x2 - x1);
                double height = Math.Abs(y2 - y1);

                // Вычисляем периметр и площадь прямоугольника
                double perimeter = 2 * (width + height);
                double area = width * height;

                // Выводим результаты на экран
                PerimeterLabel.Content = $"Периметр: {perimeter}";
                AreaLabel.Content = $"Площадь: {area}";

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
    }
}
