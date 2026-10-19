using System;
using System.Globalization;
using System.Windows;
using CoreLib;
using WSUniversalLib;

namespace ProductionApp
{
    public partial class MainWindow : Window
    {
        // Создаем объекты наших библиотек
        Calculation calc = new Calculation();
        Utils utils = new Utils();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Задание 1
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Безопасно переводим текст в числа. Если не получится - выбросит ошибку, которую мы поймаем.
                int type = int.Parse(TxtProductType.Text);
                int mat = int.Parse(TxtMaterialType.Text);
                int count = int.Parse(TxtCount.Text);

                // Убираем ВСЕ пробелы и меняем запятую на точку
                string wStr = TxtWidth.Text.Trim().Replace(',', '.');
                string lStr = TxtLength.Text.Trim().Replace(',', '.');

                float w = float.Parse(wStr, CultureInfo.InvariantCulture);
                float l = float.Parse(lStr, CultureInfo.InvariantCulture);

                // Вызов метода из библиотеки
                int res = calc.GetQuantityForProduct(type, mat, count, w, l);

                if (res == -1)
                {
                    TxtResult.Text = "Ошибка: неверные данные";
                    TxtResult.Foreground = System.Windows.Media.Brushes.Red;
                }
                else
                {
                    TxtResult.Text = "Нужно сырья: " + res;
                    TxtResult.Foreground = System.Windows.Media.Brushes.Blue;
                }
            }
            catch (Exception)
            {
                // Если ввели буквы, пустоту или несколько запятых, программа не упадет
                MessageBox.Show("Пожалуйста, введите корректные числа. Дробные числа можно вводить через запятую или точку.", "Ошибка ввода");
            }
        }

        // Задание 2
        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client(TxtLastName.Text, TxtFirstName.Text, TxtPatronymic.Text);
                string order = utils.GenerateOrderNumber(client, DateTime.Now);
                TxtOrderResult.Text = "Номер: " + order;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}   