using Lib_2;
using System;

namespace Lib_2
{
    /// <summary>
    /// Класс "Пара чисел"
    /// </summary>
    public class Pair
    {
        private int _pervoe;
        private int _vtoroe;

        public int Pervoe
        {
            get { return _pervoe; }
            set { _pervoe = value; }
        }

        public int Vtoroe
        {
            get { return _vtoroe; }
            set { _vtoroe = value; }
        }

        public Pair()
        {
            _pervoe = 0;
            _vtoroe = 0;
        }

        public Pair(int pervoe, int vtoroe)
        {
            _pervoe = pervoe;
            _vtoroe = vtoroe;
        }

        /// <summary>
        /// Метод сложения полей пары 
        /// </summary>
        /// <returns>Сумма полей</returns>
        public int Summa()
        {
            return _pervoe + _vtoroe;
        }

        /// <summary>
        /// Операция сложения двух пар: (a,b) + (c,d) = (a+c, b+d)
        /// </summary>
        public static Pair operator +(Pair p1, Pair p2)
        {
            return new Pair(p1.Pervoe + p2.Pervoe, p1.Vtoroe + p2.Vtoroe);
        }

        /// <summary>
        /// Перегруженный метод: увеличить поля на 1
        /// </summary>
        public void Yvelech_1()
        {
            _pervoe = _pervoe + 1;
            _vtoroe = _vtoroe + 1;
        }

        /// <summary>
        /// Перегруженный метод: уменьшить поля на 1
        /// </summary>
        public static Pair operator --(Pair p)
        {
            return new Pair(p.Pervoe - 1, p.Vtoroe - 1);
        }

        /// <summary>
        /// Перегруженный метод: сложение трёх пар
        /// </summary>
        public void Summatreh(Pair p2, Pair p3)
        {
            _pervoe += p2.Pervoe + p3.Pervoe;
            _vtoroe += p2.Vtoroe + p3.Vtoroe;
        }

        /// <summary>
        /// Формирование строки информации о паре
        /// </summary>
        public override string ToString()
        {
            return "(" + _pervoe + "; " + _vtoroe + ")";
        }
    }
}

class Money : Pair
{
    public Money() : base() { }
    public Money(int rub, int kop) : base(rub, kop) { }

    /// <summary>
    /// Операция сложения денег с учётом, что 100 копеек = 1 рубль
    /// </summary>
    /// <param name="m1">Первая денежная сумма</param>
    /// <param name="m2">Вторая денежная сумма</param>
    /// <returns>Новая денежная сумма</returns>
    public static Money operator +(Money m1, Money m2)
    {
        int rub = m1.Pervoe + m2.Pervoe;
        int kop = m1.Vtoroe + m2.Vtoroe;
        if (kop >= 100)
        {
            rub = rub + kop / 100;
            kop = kop % 100;
        }
        return new Money(rub, kop);
    }

    /// <summary>
    /// Операция вычитания денежных сумм: (руб1, коп1) - (руб2, коп2)
    /// </summary>
    /// <param name="m1">Уменьшаемая денежная сумма</param>
    /// <param name="m2">Вычитаемая денежная сумма</param>
    /// <returns>Новая денежная сумма</returns>
    public static Money operator -(Money m1, Money m2)
    {
        int rub = m1.Pervoe - m2.Pervoe;
        int kop = m1.Vtoroe - m2.Vtoroe;
        if (kop < 0)
        {
            rub = rub - 1;
            kop = kop + 100;
        }
        return new Money(rub, kop);
    }
    /// <summary>
    /// Операция деления денежной суммы на целое число
    /// </summary>
    /// <param name="delitel">Делитель (целое число)</param>
    /// <returns>Новая денежная сумма</returns>
    public Money Delenie(int delitel)
    {
        int vsegoKop = (Pervoe * 100 + Vtoroe) / delitel;
        return new Money(vsegoKop / 100, vsegoKop % 100);
    }
    /// <summary>
    /// Формирование строки информации о денежной сумме
    /// </summary>
    /// <returns>Строка вида X руб. X коп."</returns>
    public override string ToString()
    {
        return Pervoe + "rub." + Vtoroe + "kop.";
    }
}