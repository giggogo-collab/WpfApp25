using Lib_2;
using System;
using System.Windows;

namespace PracticalWork4
{
    public partial class MainWindow : Window
    {
        Pair pair1 = new Pair();
        Pair pair2 = new Pair();
        Pair pair3 = new Pair();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Считываем данные из полей
        private bool ChitatPari()
        {
            try
            {
                pair1.Pervoe = Convert.ToInt32(tbPervoe1.Text);
                pair1.Vtoroe = Convert.ToInt32(tbVtoroe1.Text);
                pair2.Pervoe = Convert.ToInt32(tbPervoe2.Text);
                pair2.Vtoroe = Convert.ToInt32(tbVtoroe2.Text);
                pair3.Pervoe = Convert.ToInt32(tbPervoe3.Text);
                pair3.Vtoroe = Convert.ToInt32(tbVtoroe3.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Введите целые числа во все поля!");
                return false;
            }
        }

        // Сумма полей каждой пары
        private void btnSumPolei_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatPari()) return;
            tbResultat.Text = "1 пара: " + pair1 + " сумма = " + pair1.Summa() + "\n" + "2 пара: " + pair2 + " сумма = " + pair2.Summa() + "\n" + "3 пара: " + pair3 + " сумма = " + pair3.Summa();
        }

        // Сложение двух пар
        private void btnDobavitpary_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatPari()) return;
            Pair rez = pair1 + pair2;
            tbResultat.Text = pair1 + " + " + pair2 + " = " + rez;
        }

        // Увеличение на 1
        private void btnYvelichitna1_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatPari()) return;
            pair1.Yvelech_1();
            pair2.Yvelech_1();
            pair3.Yvelech_1();

            tbPervoe1.Text = pair1.Pervoe.ToString();
            tbVtoroe1.Text = pair1.Vtoroe.ToString();
            tbPervoe2.Text = pair2.Pervoe.ToString();
            tbVtoroe2.Text = pair2.Vtoroe.ToString();
            tbPervoe3.Text = pair3.Pervoe.ToString();
            tbVtoroe3.Text = pair3.Vtoroe.ToString();
            tbResultat.Text = "После увеличения на 1:\n" + "1 пара = " + pair1 + "\n" + "2 пара = " + pair2 + "\n" + "3 пара = " + pair3;
        }

        // Уменьшение на 1
        private void btnYmenshitna1_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatPari()) return;
            pair1 = --pair1;
            pair2 = --pair2;
            pair3 = --pair3;

            tbPervoe1.Text = pair1.Pervoe.ToString();
            tbVtoroe1.Text = pair1.Vtoroe.ToString();
            tbPervoe2.Text = pair2.Pervoe.ToString();
            tbVtoroe2.Text = pair2.Vtoroe.ToString();
            tbPervoe3.Text = pair3.Pervoe.ToString();
            tbVtoroe3.Text = pair3.Vtoroe.ToString();
            tbResultat.Text = "После уменьшения на 1:\n" + "1 пара = " + pair1 + "\n" + "2 пара = " + pair2 + "\n" + "3 пара = " + pair3;
        }

        // Сложение трёх пар
        private void btnSummaTreh_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatPari()) return;
            pair1.Summatreh(pair2, pair3);
            tbPervoe1.Text = pair1.Pervoe.ToString();
            tbVtoroe1.Text = pair1.Vtoroe.ToString();
            tbResultat.Text = " + " + pair2 + " + " + pair3 + " = " + pair1;
        }

        Money m1 = new Money();
        Money m2 = new Money();

        private bool ChitatDengi()
        {
            try
            {
                m1.Pervoe = Convert.ToInt32(tbPervoe1.Text);
                m1.Vtoroe = Convert.ToInt32(tbVtoroe1.Text);
                m2.Pervoe = Convert.ToInt32(tbPervoe2.Text);
                m2.Vtoroe = Convert.ToInt32(tbVtoroe2.Text);
                return true;
            }
            catch
            {
                MessageBox.Show("Введите целые числа во все поля!");
                return false;
            }
        }

        private void btnSummaDeheg_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatDengi()) return;
            Money rez = m1 + m2;
            tbResultat.Text = m1 + " + " + m2 + " = " + rez;
        }

        private void btnRaznitsaDeneg_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatDengi()) return;
            Money rez = m1 - m2;
            tbResultat.Text = m1 + " - " + m2 + " = " + rez;
        }

        private void btnDelinieDeneg_Click(object sender, RoutedEventArgs e)
        {
            if (!ChitatDengi()) return;
            if (!int.TryParse(tbDelitel.Text, out int delitel) || delitel == 0)
            {
                MessageBox.Show("Введите целое число, не равное нулю!");
                return;
            }

            Money rez = m1.Delenie(delitel);
            tbResultat.Text = m1 + " / " + delitel + " = " + rez;
        }

        private void btnbtnOproge_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №6 Вариант 2\n" + "Использовать класс Pair (пара чисел). Определить класс-наследник Money с \r\nхарактеристиками: рубли и копейки. Переопределить операцию сложения и \r\nопределить методы вычитания и деления денежных сумм. " + "Сделал Антипов А.А.", "О программе");
        }

        private void btnVihod_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}